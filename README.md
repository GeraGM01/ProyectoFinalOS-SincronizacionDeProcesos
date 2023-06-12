# ProyectoSistemasOperativos

This project is a graphical simulation of an interaction between a bee and a bear, implemented using threads in C# for the subject of Operating Systems Fundamentals corresponding to the semester 2022-2023/II. The program simulates the behavior of the bees producing honey and the bear consuming honey from a jar.

**Overview:**
The program consists of two main classes: OsoYAbejas and Buffer<T>, along with a Windows Forms UI class Form1. The OsoYAbejas class represents the interaction between bees and a bear, where bees produce honey and the bear consumes it. The Buffer<T> class acts as a buffer to store and retrieve items between the producer (bees) and the consumer (bear).

**User Interface:**
The Form1 class is a Windows Forms UI that provides a graphical representation of the honey production process. It displays the current capacity of the honey buffer, the number of bees, and the state of the bear. The UI also includes images of bees, a bear, and a honey jar to visually represent the system's state.
  
**Usage:**
- Run the application.
- Click the "Start" button to initiate the honey production process.
- The UI will display the current state of the honey buffer, bees, and bear.
- Once the honey jar is full, the bear will wake up, consume the honey, and notify the bees to continue their work.
- The process continues indefinitely until the application is closed or the "Stop" button is clicked.
  
**Note:** The GUI elements and image paths in the code are specific to the original implementation and may need to be adjusted accordingly.
  
**Compilation and code execution screenshots**

  ![Captura de pantalla 2023-06-02 133445](https://github.com/GeraGM01/ProyectoFinalOS-SincronizacionDeProcesos/assets/103235519/1db22663-f0bc-4d60-8800-49c656ece505)

  ![Captura de pantalla 2023-06-02 133616](https://github.com/GeraGM01/ProyectoFinalOS-SincronizacionDeProcesos/assets/103235519/fdd37e00-5645-4bfd-a468-b06730e0588f)
