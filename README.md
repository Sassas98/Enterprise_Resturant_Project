# Come Eseguire il Progetto
1. Ristorare il DB Enterprise di cui può trovare il dump qui sulla cartella principale della repository git.
2. Avviare il progetto. Swagger si aprirà automaticamente.
3. La prima chiamata che bisogna fare è quella di sign in. c'è un valore numerico che determina il ruolo. 0 è utente e 1 è amministratore. la password deve essere lunga almeno 8 caratteri e l'indirizzo email deve essere un indirizzo email ed essere univoco.
4. per l'autenticazione tramite jwt occorre inserire email e password.
5. una volta ottenuto il token ed effettuata l'autenticazione anche le altre due chiamate diventano disponibili.
