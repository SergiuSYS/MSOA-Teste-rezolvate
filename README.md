# MSOA-Teste-rezolvate

# 📘 Ghid pentru Crearea unei Baze de Date Locale în Visual Studio

## 1. Deschiderea uneltelor necesare
- `View > Server Explorer`
- `View > Other Windows > Data Sources`

---

## 2. Crearea bazei de date
În fereastra **Server Explorer**:
- Click pe **Add New Connection**
- Configurează noua conexiune

![imagine](ImaginiReadMe/CreateDataBase.png) <!-- înlocuiește cu URL sau path către imagine -->

---

## 3. Crearea tabelelor
- Creează tabelele în baza de date

![imagine](ImaginiReadMe/CreateTable.png)

- Dacă un tabel conține o **cheie externă** (*foreign key*), setează opțiunea:
  ```sql
  ON DELETE CASCADE
  ```
- Astfel, ștergerile vor fi propagate automat în tabelele legate.
- După finalizarea tabelelor, apasă Update pentru a salva modificările.

## 4. Conectarea bazei de date la Form
Deschide formularul (Form)

Mergi la tabul Data Sources

Apasă pe Add New Data Source
Selectează:
- Database
- Dataset
- Next > Next
- Alege tabelele dorite

![imagine](link_catre_imagine_3)
