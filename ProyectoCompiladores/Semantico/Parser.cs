using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCompiladores.Analisis_Lexico;
using ProyectoCompiladores.Gramatica;
using ProyectoCompiladores.Tokens;

namespace ProyectoCompiladores.Semantico
{
    public class Parser
    {
        private static TokenInfo actualInfo;
        private static Token token;
        private List<TokenInfo> tokens;

        Entorno entornoActual;

        public Parser(Lexer lexer)
        {
            // this.lexer = lexer;
            entornoActual = new Entorno(null);
            tokens = lexer.TokensFilteredInfo;
            mover();

        }
        private int index = 0;
        private void mover()
        {
            actualInfo = tokens[index++];
            // actualInfo = lexer.Explorar();
            token = actualInfo.Token;
        }
        private TokenInfo Peek()
        {
            return tokens[index];
        }
        public static void error(String s)
        {
            throw new Exception("cerca de linea " + actualInfo.Line + ": " + s);
        }
        private bool eat(TokenType type)
        {
            if (token.TokenType == type)
            {
                mover();
                return true;
            }
            else
            {
                error("Se esperaba " + type.ToString());
                return false;
            }
        }

        // top-level parsing method: MainClass ClassDecl*
        public Program2 parseProgram()
        {
            MainClass main = parseMainClass();
            return new Program2(main);
        }

        private MainClass parseMainClass()
        {
            parseImports();
            if (token.TokenType == TokenType.PUBLIC)
                eat(TokenType.PUBLIC);

            eat(TokenType.CLASS);
            Identifier className = parseIdentifier(Tipo.Class);
            eat(TokenType.LLAVEI);
            eat(TokenType.PUBLIC);
            eat(TokenType.STATIC);
            eat(TokenType.VOID);
            eat(TokenType.MAIN);
            eat(TokenType.IPAREN);
            eat(TokenType.STRING);
            eat(TokenType.ident);
            eat(TokenType.DPAREN);

            Statement stm = parseStatement();

            eat(TokenType.LLAVED);

            MethodDecl mainMethod = new MethodDecl(Tipo.Int, new Identifier(new Palabra("main", TokenType.MAIN), Tipo.Int), stm);
            return new MainClass(className, mainMethod);
        }

        private void parseImports()
        {
            while (token.TokenType == TokenType.IMPORT)
            {
                eat(TokenType.IMPORT);
                eat(TokenType.ident);
                while (token.TokenType == TokenType.PUNTO)
                {
                    eat(TokenType.PUNTO);
                    if (token.TokenType == TokenType.OPMULTI)
                    {
                        eat(TokenType.OPMULTI);
                        break;
                    }
                    eat(TokenType.ident);
                }
                eat(TokenType.PUNTOYCOMA);
            }
        }

        private Identifier parseIdentifier(Tipo tipo)
        {
            Identifier id = null;

            // grab ID value if token type is ID
            if (token.TokenType == TokenType.ident)
            {
                id = new Identifier(token, tipo);
            }
            if (entornoActual.Get(token) != null)
            {
                error(token.Lexeme + " ha sido declarado previamente");
            }
            entornoActual.Put(token, id);
            eat(TokenType.ident);
            return id;
        }
        // Variable declaration: Type id ; OR Type id  = expresion ;
        private VarDecl parseVarDecl()
        {
            Tipo type = parseType();
            Identifier id = parseIdentifier(type);
            if (token.TokenType == TokenType.ASIGNACION)
            {
                eat(TokenType.ASIGNACION);
                Asignacion instr = new Asignacion(id, parseExpression());
                VarDeclAndAsig declAndAsig = new VarDeclAndAsig(type, id, instr);
                eat(TokenType.PUNTOYCOMA);
                return declAndAsig;
            }
            eat(TokenType.PUNTOYCOMA);
            return new VarDecl(type, id);
        }

        private Tipo parseType()
        {
            switch (token.TokenType)
            {
                case TokenType.INT:
                    eat(TokenType.INT);
                    return Tipo.Int;
                case TokenType.BOOLEAN:
                    eat(TokenType.BOOLEAN);
                    return Tipo.Bool;
                case TokenType.FLOAT:
                    eat(TokenType.FLOAT);
                    return Tipo.Float;
                case TokenType.DOUBLE:
                    eat(TokenType.DOUBLE);
                    return Tipo.Float;
                case TokenType.STRING:
                    eat(TokenType.STRING);
                    return Tipo.String;
                case TokenType.CHAR:
                    eat(TokenType.CHAR);
                    return Tipo.Char;
            }
            return null;
        }
        private Statement parseStatement()
        {
            // Bloque
            if (token.TokenType == TokenType.LLAVEI)
            {
                entornoActual = new Entorno(entornoActual);
                eat(TokenType.LLAVEI);
                // recursively call parseStatement() until closing brace
                StatementList stms = new StatementList();
                while (token.TokenType != TokenType.LLAVED && token.TokenType != TokenType.EOF)
                    stms.addElement(parseStatement());
                eat(TokenType.LLAVED);
                entornoActual = entornoActual.Anterior;
                return new Block(stms, entornoActual);
            }

            switch (token.TokenType)
            {
                case TokenType.PUNTOYCOMA:
                    eat(TokenType.PUNTOYCOMA);
                    return Statement.Null;
                case TokenType.IF:
                    eat(TokenType.IF);
                    // parse conditional expression
                    eat(TokenType.IPAREN);
                    Exp condExp = parseExpression();
                    eat(TokenType.DPAREN);
                    Statement trueStm = parseStatement();
                    if (token.TokenType != TokenType.ELSE)
                        return new If(condExp, trueStm);
                    eat(TokenType.ELSE);
                    Statement falseStm = parseStatement();
                    return new Else(condExp, trueStm, falseStm);
                case TokenType.WHILE:
                    eat(TokenType.WHILE);
                    eat(TokenType.IPAREN);
                    Exp x = parseExpression();
                    eat(TokenType.DPAREN);
                    Statement loopStm = parseStatement();
                    While nodowhile = new While(x, loopStm);
                    return nodowhile;
                case TokenType.DO:
                    eat(TokenType.DO);
                    Statement loopStnm = parseStatement();

                    eat(TokenType.WHILE);
                    eat(TokenType.IPAREN);
                    Exp bulcleBody = parseExpression();
                    eat(TokenType.DPAREN);
                    eat(TokenType.PUNTOYCOMA);
                    return new Do(loopStnm, bulcleBody);
                case TokenType.FOR:
                    entornoActual = new Entorno(entornoActual); // Crera un nuevo entorno para el bucle for
                    eat(TokenType.FOR);
                    eat(TokenType.IPAREN);
                    Statement declararion;
                    if (token.TokenType != TokenType.ident)
                        declararion = parseVarDecl();
                    else
                        declararion = Asignar();
                    Exp loopExpr = parseExpression();
                    eat(TokenType.PUNTOYCOMA);
                    Asignacion incExpr = Asignar(bucleFor: true);
                    eat(TokenType.DPAREN);
                    Statement stm = parseStatement();
                    entornoActual = entornoActual.Anterior;
                    return new For(declararion, loopExpr, incExpr, stm);
                case TokenType.ident:
                    if (token.Lexeme == "System")
                    {
                        eat(TokenType.ident);
                        eat(TokenType.PUNTO);
                        if (token.Lexeme != "out") error("Se esperaba out");
                        eat(TokenType.ident);
                        eat(TokenType.PUNTO);
                        if (token.Lexeme != "println") error("Se esperaba out");
                        eat(TokenType.ident);
                        eat(TokenType.IPAREN);
                        Exp expresion = parseExpression();
                        eat(TokenType.DPAREN);
                        return new Print(expresion);
                    }
                    return Asignar();
            }

            switch (token.TokenType)
            {

                // int and boolean signals start of var declaration
                case TokenType.INT:
                    return parseVarDecl();
                case TokenType.BOOLEAN:
                    return parseVarDecl();
                case TokenType.FLOAT:
                    return parseVarDecl();
                case TokenType.STRING:
                    return parseVarDecl();
                case TokenType.CHAR:
                    return parseVarDecl();
                case TokenType.DOUBLE:
                    return parseVarDecl();
            }


            // statement type unknown
            error("Error no se esperaba " + token.TokenType);
            return null;
        }

        private Asignacion Asignar(bool bucleFor = false)
        {
            Asignacion instr = null;
            Token t = token;
            eat(TokenType.ident);
            Identifier id = entornoActual.Get(t);
            if (id == null) error(t.ToString() + " no declarado");
            if (token.TokenType == TokenType.ASIGNACION)
            { // S -> id = E ;
                eat(TokenType.ASIGNACION);
                instr = new Asignacion(id, parseExpression());
            }
            else if (token.TokenType == TokenType.OPMASMAS)
            {
                eat(TokenType.OPMASMAS);
                instr = new Asignacion(id, new Arit(new Token("+", TokenType.OPMAS), id, new Constante(new Num(1), Tipo.Int)));
            }
            else if (token.TokenType == TokenType.OPMENOSMENOS)
            {
                eat(TokenType.OPMENOSMENOS);
                instr = new Asignacion(id, new Arit(new Token("-", TokenType.OPMENOS), id, new Constante(new Num(1), Tipo.Int)));

            }// TODO arreglos

            if (!bucleFor) // Sino es bucle for come el punto y coma
                eat(TokenType.PUNTOYCOMA);
            return instr;
        }

        private Exp parseExpression()
        {
            Exp x = unir();
            while (token.TokenType == TokenType.LOR)
            {
                Token tok = token; eat(TokenType.LOR); x = new Or(x, unir());
            }
            return x;
        }

        Exp unir()
        {
            Exp x = igualdad();
            while (token.TokenType == TokenType.LAND)
            {
                Token tok = token; eat(TokenType.LAND); x = new And(x, igualdad());
            }
            return x;
        }
        Exp igualdad()
        {
            Exp x = rel();
            while (token.TokenType == TokenType.IGUAL || token.TokenType == TokenType.DIFERENTE)
            {
                Token tok = token; mover(); x = new Relacion(tok, x, rel());
            }
            return x;
        }
        Exp rel()
        {
            Exp x = expr();
            Token tok;
            switch (token.TokenType)
            {
                case TokenType.MENOR:
                    tok = token; mover(); return new Relacion(tok, x, expr());
                case TokenType.MENORIGUAL:
                    tok = token; mover(); return new Relacion(tok, x, expr());
                case TokenType.MAYORIGUAL:
                    tok = token; mover(); return new Relacion(tok, x, expr());
                case TokenType.MAYOR:
                    tok = token; mover(); return new Relacion(tok, x, expr());
                default:
                    return x;
            }
        }
        Exp expr()
        {
            Exp x = term();
            while (token.TokenType == TokenType.OPMAS || token.TokenType == TokenType.OPMENOS)
            {
                Token tok = token; mover(); x = new Arit(tok, x, term());
            }
            return x;
        }
        Exp term()
        {
            Exp x = unario();
            while (token.TokenType == TokenType.OPMULTI || token.TokenType == TokenType.OPDIV)
            {
                Token tok = token; mover(); x = new Arit(tok, x, unario());
            }
            return x;
        }
        Exp unario()
        {
            if (token.TokenType == TokenType.OPMENOS)
            {
                eat(TokenType.OPMENOS); return new Unario(Palabra.MINUS, unario());
            }
            else if (token.TokenType == TokenType.LNOT)
            {
                Token tok = token; eat(TokenType.LNOT); return new Not(tok, unario());
            }
            else return factor();
        }
        Exp factor()
        {
            Exp x = null;
            switch (token.TokenType)
            {
                case TokenType.IPAREN:
                    eat(TokenType.IPAREN); x = parseExpression(); eat(TokenType.DPAREN);
                    return x;
                case TokenType.INT:
                    x = new Constante(token, Tipo.Int); eat(TokenType.INT); return x;
                case TokenType.FLOAT:
                    x = new Constante(token, Tipo.Float); eat(TokenType.FLOAT); return x;
                case TokenType.booleanConstant:
                    x = Constante.True; eat(TokenType.booleanConstant); return x;
                case TokenType.FALSE:
                    x = Constante.False; eat(TokenType.FALSE); return x;
                case TokenType.ident:
                    Identifier id = entornoActual.Get(token);
                    if (id == null) error(token.Lexeme + " no declarado");
                    eat(TokenType.ident);
                    return id;
                case TokenType.stringConstant:
                    Token tok = token;
                    eat(TokenType.stringConstant);
                    return new Exp(tok, Tipo.String);
                default:
                    error("error de sintaxis");
                    return x;

            }
        }
    }
}
