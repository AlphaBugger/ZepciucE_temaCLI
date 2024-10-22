1.Modificarea MatrixMode.Projection schimbă modul în care scena este redată, influențând percepția adâncimii și dimensiunilor obiectelor.

### Răspunsuri la întrebări

**Ce este un viewport?**  
Viewport-ul reprezintă zona din fereastră în care OpenGL desenează imaginea; dimensiunea și poziția acestuia pot fi ajustate pentru a se adapta ferestrei sau pentru a obține diferite aspecte ale imaginii.

---

**Ce reprezintă conceptul de frames per second din punctul de vedere al bibliotecii OpenGL?**  
Frame rate-ul (FPS) indică numărul de cadre pe care aplicația le poate reda într-o secundă; un FPS mai mare duce la o animație mai fluidă, iar OpenGL se străduiește să mențină un FPS constant pentru a îmbunătăți experiența utilizatorului.

---

**Când este rulată metoda `OnUpdateFrame()`?**  
Metoda `OnUpdateFrame()` este rulată la fiecare ciclu de actualizare, înainte de redarea efectivă a scenei, și este utilizată pentru a gestiona logica jocului, cum ar fi input-ul utilizatorului și actualizarea stării aplicației.

---

**Ce este modul imediat de randare?**  
Modul imediat de randare permite desenarea primitivelor prin apeluri repetate ale funcțiilor de desenare (de exemplu, `GL.Begin`, `GL.End`); este ineficient din cauza numeroaselor apeluri de funcții și este recomandat să se evite în aplicațiile moderne.

---

**Care este ultima versiune de OpenGL care acceptă modul imediat?**  
Modul imediat a fost suportat până la OpenGL 3.5; versiunile ulterioare promovează tehnici mai eficiente de randare, cum ar fi utilizarea shader-elor și a buffer-elor.

---

**Când este rulată metoda `OnRenderFrame()`?**  
Metoda `OnRenderFrame()` este rulată la fiecare ciclu de randare, după actualizarea logicii aplicației, și este utilizată pentru a desena scena actualizată pe ecran.

---

**De ce este nevoie ca metoda `OnResize()` să fie executată cel puțin o dată?**  
Metoda `OnResize()` este necesară pentru a ajusta viewport-ul și matricea de proiecție atunci când fereastra este redimensionată; trebuie apelată cel puțin o dată pentru a asigura corectitudinea desenării.

---

**Ce reprezintă parametrii metodei `CreatePerspectiveFieldOfView()` și care este domeniul de valori pentru aceștia?**  
Parametrii metodei `CreatePerspectiveFieldOfView()` includ:
- **FOV (Field of View)**: unghiul de vizualizare, în radiani (de obicei între 0.1 și π/2).
- **Aspect Ratio**: raportul lățime/înălțime al ferestrei.
- **Near**: distanța minimă de tăiere (0.1 sau mai mare).
- **Far**: distanța maximă de tăiere, care trebuie să fie mai mare decât Near.
