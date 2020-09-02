# credit-approval Solution
API REST application which describes the credit approval process of a fictitious company based on customer ranks

# User Story for the application
Historia de usuario: Aprobar créditos en base a indicadores

Como María quiero poder aprobar créditos basando mi decisión en indicadores de tal manera que la calidad de las operaciones aprobadas sea la mejor y no tengamos una cartera morosa grande. 

Criterios de aceptación

Dado que mi perfil dentro del sistema me permite aprobar créditos
Cuando reciba una solicitud de aprobación de un crédito personal por un monto menor o igual a 50 mil dólares y desee saber si debo o no aprobar dicha solicitud el sistema debe permitir analizar los indicadores de este cliente. 
Entonces el sistema me debe mostrar una bandeja con las solicitudes de crédito que tengo por aprobar. Por cada solicitud el sistema me debe permitir analizar el monto total de la deuda registrada por la SBS para este cliente, además me debe mostrar la puntuación del cliente como deudor a través de la central de riesgo sentinel (para este caso, este indicador puede ser bueno, regular o malo) y finalmente me debe mostrar el indicador de nuestro algoritmo de inteligencia artificial que apoya mi decisión (este indicador muestra un puntaje del 1 al 10 siendo 10 un crédito seguro y 1 un crédito a pérdida). Finalmente, debe permitirme con un botón aprobar o denegar la solicitud de crédito. 

Consideraciones: tanto el monto total de deuda registrada en la SBS, el indicador de sentinel y el algoritmo de inteligencia artificial son ficticios. Coloca cualquier valor que le dé sentido a la historia cuando construyas el caso. 


# Environment Steps
# First : Migrations
The application needs to run the next 2 commands in Package Manager Console:
1.- Add-Migration DbInit
2.- Update-Database
