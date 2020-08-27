# ProyectoCompiladores
Proyecto Compiladores 2020
El siguiente repositorio contiene dos carpetas, una con la solución del mini java para correrlo en Visual Studio. Y una segunda que contiene un instalador
y reparador de la aplicación de escritorio. El instalador se encuentra dentro de la carpeta debug. 
El manejo de errores se crearon primero las clases token, tokeninfo y tokentype, en ellas definimos lo que el analizador acepta o no y a que token pertenece,
lo envía a la clase token la cual se encarga de verificar su tipo y luego revisa lo que son validas del tipo. Ejemplo: String pasa por type y reconoce una palabra reservada, 
procede entonces a info a revisar exactamente cual reservada es. También contamos con las clases num, entero, real, palabra que verifican si está bien su escritura y en lexer 
es donde creamos todo el analizador. De no encontrar algo válido, procede a en tokentype a extraer "Error". Todo aquello que no se haya agregado a los tokens el programa lo 
considera como un error.
