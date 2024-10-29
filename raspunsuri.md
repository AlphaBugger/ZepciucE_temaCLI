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


### TEMA Lsaborator 3


# Răspunsuri la întrebări

1. **Care este ordinea de desenare a vertexurilor pentru aceste metode (orar sau anti-orar)? Desenați axele de coordonate din aplicația-template folosind un singur apel GL.Begin().**  
   Ordinea de desenare a vertexurilor depinde de orientarea lor. În OpenGL, ordinea anti-orară este folosită pentru fațetele frontale, în timp ce ordinea orară este pentru fațetele din spate. Pentru desenarea axelor de coordonate într-un singur apel `GL.Begin()`, folosiți `GL_LINES` pentru a desena o linie pentru fiecare axă.

---

2. **Ce este anti-aliasing? Prezentați această tehnică pe scurt.**  
   Anti-aliasing-ul este o tehnică utilizată pentru a netezi marginile obiectelor grafice prin estomparea treptată a culorii pixelilor. Astfel, ajută la reducerea efectului de „scară” sau „zigzag” la contururi, oferind o imagine mai clară și estetică.

---

3. **Care este efectul rulării comenzii GL.LineWidth(float)? Dar pentru GL.PointSize(float)? Funcționează în interiorul unei zone GL.Begin()?**  
   `GL.LineWidth(float)` schimbă grosimea liniilor desenate în OpenGL, iar `GL.PointSize(float)` controlează dimensiunea punctelor. Ambele comenzi pot fi folosite în afara și în interiorul unui apel `GL.Begin()`, dar e recomandat să le setați înainte de `GL.Begin()` pentru o consistență mai bună.

---

4. **Care este efectul utilizării directivei LineLoop, LineStrip, TriangleFan și TriangleStrip atunci când desenați segmente de dreaptă multiple în OpenGL?**  
   - **LineLoop**: Conectează toate punctele într-o buclă continuă, închizând forma.
   - **LineStrip**: Creează o linie continuă, conectând toate punctele fără a le închide într-un cerc.
   - **TriangleFan**: Creează triunghiuri care au un punct comun, ideal pentru desenarea de discuri sau conuri.
   - **TriangleStrip**: Creează triunghiuri în lanț, folosind fiecare punct adăugat pentru a forma un nou triunghi conectat la precedentul.

---

5. **Creați un proiect elementar. Urmăriți exemplul furnizat cu titlu de demonstrație - OpenGL_conn_ImmediateMode. Atenție la setarea viewport-ului.**  
   Exemplul `OpenGL_conn_ImmediateMode` arată cum să utilizați `GL.Begin()` și `GL.End()` pentru a desena primitive simple. Viewport-ul poate fi setat folosind `GL.Viewport()`, unde lățimea și înălțimea ar trebui să fie ajustate la dimensiunea ferestrei pentru o reprezentare corectă.

---

6. **De ce este importantă utilizarea de culori diferite (în gradient sau culori selectate per suprafață) în desenarea obiectelor 3D? Care este avantajul?**  
   Utilizarea culorilor diferite în gradient sau per suprafață ajută la crearea unei percepții mai bune a formei și adâncimii obiectelor 3D. Aceasta oferă un efect vizual realist, evidențiind fațetele și îmbunătățind lizibilitatea obiectelor complexe.

---

7. **Ce reprezintă un gradient de culoare? Cum se obține acesta în OpenGL?**  
   Un gradient de culoare reprezintă o tranziție lină între două sau mai multe culori. În OpenGL, se obține setând culori diferite pentru fiecare vertex al unei primitive, iar interpolarea culorilor între vertexuri va genera gradientul.

---

8. **Creați o aplicație care la apăsarea unui set de taste va modifica culoarea unui triunghi între valorile minime și maxime, pentru fiecare canal de culoare. Ce efect va apărea la utilizarea canalului de transparență?**  
   La utilizarea canalului de transparență, triunghiul va deveni mai opac sau mai transparent în funcție de valoarea setată pentru alfa. Acest lucru va permite obiectelor din spatele triunghiului să fie parțial vizibile prin el.

---

9. **Modificați aplicația pentru a manipula valorile RGB pentru fiecare vertex ce definește un triunghi. Afișați valorile RGB în consolă.**  
   Pentru fiecare vertex al triunghiului, ajustați valorile RGB și afisați-le în consolă. Aceasta oferă un control detaliat al culorilor fiecărui vertex, permițând observarea efectelor interpolării pe fața triunghiului.

---

10. **Ce efect are utilizarea unei culori diferite pentru fiecare vertex atunci când desenați o linie sau un triunghi în modul strip?**  
    În modul strip, utilizarea unei culori diferite pentru fiecare vertex produce o tranziție lină de culori de-a lungul liniei sau a suprafeței triunghiurilor, datorită interpolării de culori efectuate de OpenGL între vertexuri.
