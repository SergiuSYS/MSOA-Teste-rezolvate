# MSOA-Teste-rezolvate

# cum folosesti baza de date in visualstudio C#
  ```C#
     [numele tabelei]TableAdapter adapter[numele tabelei] = new [numele tabelei]TableAdapter();
      //exemplu
     StudentiTableAdapter adapterStudenti = new StudentiTableAdapter();

     //cu ajutorul adapterStudenti putem primi date, insera, update si sterge
     adapterStudenti.GetData();
     adapterStudenti.Insert();
     adapterStudenti.Update();
     adapterStudenti.Delete();
  
    //recomanda ca in momentul in care preluati datele sa le puneti intr-o lista sa fie mult mia usor de manipulat
    var studentii = adapterStudenti.GetData().toList();
  
  ```
# TreeView:

TreeNode.Tag poate stoca orice tip de obiect:
 ```C#
//in cazul obiectelor create
Student newStudent = new Student("Sergiu", 1, 8);
TreeNode newNode = new TreeNode(newStudent.Nume);  
newNode.Tag = newStudent;                          
treeView1.Nodes.Add(newNode);

//daca vrei sa salvezi datele dintr-o baza de date trebuie salvata intreaga linie in .tag

 StudentiTableAdapter adapterStudenti = new StudentiTableAdapter();
 var data = adapterStudenti.GetData().toList(); // va returna o lista intreaga cu toate linile
 
foreach(var row in data)
{
	TreeNode newNode = new TreeNode(row.Nume);
	newNode.tag = row //asa putem tine in memorie toate datele
	treeView1.Nodes.Add(newNode);
}
```

recuperarea obiectului in momentul selectari nodulu:
important este sa ii precizezi tipul de obiect "as Student"
 ```C#
//preluarea unui obiect
var data = treeView1.SelectedNode.Tag as Student;

important este sa ii precizezi tipul de obiect "as student"
dupa preluarea datelor se pot manipula
```

preluarea unei lini de baza de date salvate in treeView
 ```C#
var data = treeView1.SelectedNode.Tag as [Denumireabazei de date]DataSet.[Denumirea tabelului]Row;

var data = treeView1.SelectedNode.Tag as FacultateDataSet.StudentiRow; //pentru a spune explicit ce tip de data este

//acum putem face ce vrem cu acea linie cu data.Nume ii preluam numele din linie data.Id data.An etc 
```



# ComboBox:

comboBox poate tine obiecte in el nu doar stringuri:
```C#
//exista clasa Student 
public class Student
{
    public string Nume { get; set; }
    public int An { get; set; }
    public double Medie { get; set; }

    public Student(string nume, int an, double medie)
    {
        Nume = nume;
        An = an;
        Medie = medie;
    }
//pentru a nu i se trece tipul de data in combobox cand adaugam o instanta a acestui obiect trebuie sa facem override  la ToString()
//in momentul in care adaugi obiectul in combobox acesta il va denumi dupa ce returneaza functia ToString()
   
    public override string ToString()
    {
        return Nume; // Ce apare în ComboBox
    }

}
```

cum functioneaza adugarea:
```C#
Student student1 = new Student("Ana", 1, 9.5);
Student student2 = new Student("Paul", 2, 8.8);

comboBox1.Items.Add(student1);
comboBox1.Items.Add(student2);
```
preluarea unui obiect saelectat se face: 
```C#
var studentSelectat = comboBox1.SelectedItem as Student;
```

# Directoare si fisiere:

directoarele se creaza cu ajutorul lui "Directory":
```C#
Directory.CreateDirectory(("file path + denuirea lui");
Directory.CreateDirectory(("C:\\Users\\Sergiu\\Desktop\\FolderTest"); //va crea un folder test in Desktop
```
pentru fisiere flosim "FILE":
```C#
File.WriteAllText("file path + denuirea lui", "stringul cu date in el");
string data = "Hello World !!!";
File.WriteAllText("C:\\Users\\Sergiu\\Desktop\\FolderTest\\fisier1.txt",data); // se va crea un fisier cu denumirea fisier1.txt si Hello World !!! scris in el 

//cand salvam obiecte este de preferat sa folosim "\n" incat sa le scriem pe lini separate
//va fi mult mai usor la preluarea datelor pentru ca nu mai facem split.
```
preluarea datelor se face to cu ajutorul lui "DIRECTORY" si "FILE":

pentru directoare:
```C#
Directory.GetDirectories("pathul unde vream sa cautam folderele");
Directory.GetDirectories("C:\\Users\\Sergiu\\Desktop"); //imi va returna o lista de paturi catre folderele aflata in interiorul lui Desktop 
//EX: ["C:\\Users\\Sergiu\\Desktop\\FolderTest", "C:\\Users\\Sergiu\\Desktop\\FolderImagini", ....]
```
pentru a primi o lista de fisiere:
```C#
Directory.GetFiles("pathul unde vream sa cautam fisierele"); 
Directory.GetFiles("C:\\Users\\Sergiu\\Desktop\\FolderTest") // va returna o lista de pathuri catre fisierele din FolderTest
```
pentru a citi un fisier:
```C#
 File.ReadAllLines("pathul catre fisier");
 File.ReadAllLines("C:\\Users\\Sergiu\\Desktop\\FolderTest\\fisier1.txt"); imi va returna Hello World !!!
 
 /* in cazul in care fisierul arata asa
  * Sergiu
  * anul 2
  * medie 8
  */
 File.ReadAllLines va returna o lista de stringuri ["Sergiu", "anul 2", "media 8"];
```

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

![imagine](ImaginiReadMe/ConfigurareDataBase.png)

---

## 3. Crearea tabelelor
- Creează tabelele în baza de date

![imagine](ImaginiReadMe/CreateTable.png)

- Dacă un tabel conține o **cheie externă** (*foreign key*), setează opțiunea:
  ```sql
  ON DELETE CASCADE
  ```
  Exemplu;
  ```sql
  CREATE TABLE [dbo].[Student] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Nume] NVARCHAR(50) NOT NULL
  );
  
  CREATE TABLE [dbo].[Materii](
      [Id] INT PRIMARY KEY IDENTITY(1,1),
      [Denumire] NVARCHAR(30) NOT NULL,
      [NotaFinala] INT NOT NULL,
      [StudentId] INT NOT NULL FOREIGN KEY REFERENCES Student(Id) ON DELETE CASCADE
  );
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

![imagine](ImaginiReadMe/SelectareTabele.png)

---
## 5. O mica modificare in setarile bazei de date
din file explorer selecteaza baza de date si in proprietatiile pui:
- Copy to Output Directory pe Copy if newer

![imagine](ImaginiReadMe/CopyIfNever.png)

este o setare sa sa se salveze in baza de date nu local in \bin\Debug.
