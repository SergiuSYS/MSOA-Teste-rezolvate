# MSOA-Teste-rezolvate

 Ghid pentru Crearea unei Baze de Date Locale în Visual Studio

 1. Deschiderea uneltelor necesare
    - View > Server Explorer
    - View > Other Windows > Data Sources
  2. Crearea bazei de date
     În fereastra Server Explorer:
     facem un New Connection
     [imagine]
  3. Crearea tabelelor:
     [Imagine]
     Dacă un tabel conține o cheie externă (foreign key), setează opțiunea ON DELETE CASCADE pentru ca ștergerile să se reflecte automat și în tabelele legate
     După finalizarea tabelelor face UPDATE
  4. Conectarea bazei de date la Form
     deschdem form ul
     intri pe tabul Data sources
     adaugi un nopu data source
     [imagine]

     dupa selectezi Database > Dataset > next > next
     apoi selectezi tabelele dorite
     [imagine]
