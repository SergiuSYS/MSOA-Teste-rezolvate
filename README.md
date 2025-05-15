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

![imagine](link_catre_imagine_1) <!-- înlocuiește cu URL sau path către imagine -->

---

## 3. Crearea tabelelor
- Creează tabelele în baza de date

![imagine](link_catre_imagine_2)

- Dacă un tabel conține o **cheie externă** (*foreign key*), setează opțiunea:
  ```sql
  ON DELETE CASCADE
  ```
-Astfel, ștergerile vor fi propagate automat în tabelele legate.
-După finalizarea tabelelor, apasă Update pentru a salva modificările.
