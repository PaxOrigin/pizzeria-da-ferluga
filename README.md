# pizzeria-da-ferluga
Test di fine modulo
## Considerazioni

Ho violato parecchi principi solid, con business logic associata a singole mega classi  
- Manca IOC
- Mancano funzioni di gestione file che sono state messe nel program
- Mancano operazioni di controllo sui dati inseriti, eccezioni ed errori non sono gestite
- Avrei preferito riordinare la business logic, con classi ed interfacce specifiche che si occupano di spostare i file
- Avrei aggiunto una cartella Failed Orders nella quale finiscono gli ordini il cui processing fallisce
- Avrei voluto usare il config file che ora come ora non ha alcuna utilita
- Potrebbero esserci classi non utilizzate.