### **App 1: Simple Accordion/FAQ Item**

This application will display a single FAQ item. When the user clicks the question, the answer will be revealed.

*   **Section 3: Creating Components & Designing UI**
    *   We will build one main component: `<AccordionItem>`.
    *   This component will render a question and conditionally render an answer.
    1.  Inside your `/src` folder, create a `components` folder.
    2.  Create a new file named `AccordionItem.js` inside `/src/components`.
    3.  Create a simple CSS file `Accordion.css` in `/src/components`.

*   **Section 4: Using JSX**
    *   JSX will be used to structure the question and answer sections. We will use curly braces `{}` to display the text content passed into the component.

*   **Section 5: Data Propagation (Props)**
    *   The `AccordionItem` component will receive the `question` and `answer` as props from its parent (`App.js`), making it reusable for any FAQ pair.

*   **Section 6: Managing the Internal State (`useState` Hook)**
    *   We will use `useState` to manage whether the accordion item is currently open or closed. A boolean state (`isOpen`) will track this. Clicking the question will toggle this state.

**Step-by-Step Code:**

1.  **Create `src/components/AccordionItem.js`**
    ```javascript
    // src/components/AccordionItem.js
    import React, { useState } from 'react';
    import './Accordion.css'; // We'll create this for styling

    // This component receives 'question' and 'answer' via props
    function AccordionItem({ question, answer }) {
      // useState to manage if the answer is visible. Initial state is 'false' (closed).
      const [isOpen, setIsOpen] = useState(false);

      // This function will be called when the question is clicked
      const toggleOpen = () => {
        setIsOpen(!isOpen); // Toggles the state from true to false and vice-versa
      };

      return (
        <div className="accordion-item">
          {/* The onClick event triggers our state change */}
          <div className="accordion-question" onClick={toggleOpen}>
            {question}
            <span>{isOpen ? '-' : '+'}</span>
          </div>
          {/* JSX conditional rendering: if isOpen is true, render the answer */}
          {isOpen && <div className="accordion-answer">{answer}</div>}
        </div>
      );
    }

    export default AccordionItem;
    ```

2.  **Create `src/components/Accordion.css`**
    ```css
    .accordion-item {
      border: 1px solid #ccc;
      border-radius: 5px;
      margin: 10px 0;
      width: 400px;
    }
    .accordion-question {
      background-color: #f1f1f1;
      padding: 15px;
      cursor: pointer;
      display: flex;
      justify-content: space-between;
      font-weight: bold;
    }
    .accordion-answer {
      padding: 15px;
      border-top: 1px solid #ccc;
    }
    ```

3.  **Update `src/App.js` to use the component**
    ```javascript
    // src/App.js
    import React from 'react';
    import AccordionItem from './components/AccordionItem';
    import './App.css';

    function App() {
      const faqItem = {
        question: 'What is React?',
        answer: 'React is a JavaScript library for building user interfaces.'
      };

      return (
        <div className="App">
          <h1>Frequently Asked Questions</h1>
          {/* We pass the question and answer down as props */}
          <AccordionItem
            question={faqItem.question}
            answer={faqItem.answer}
          />
          <AccordionItem
            question="How do you manage state in React?"
            answer="You can use the useState hook for basic component state."
          />
        </div>
      );
    }

    export default App;
    ```

---

### **App 2: Configurable Greeting Card**

This application will display a greeting card that can be customized via props and has a button to change the greeting message.

*   **Section 3: Creating Components & Designing UI**
    *   We will create a `<GreetingCard>` component.
    1.  Inside `/src/components`, create a file named `GreetingCard.js`.

*   **Section 4: Using JSX**
    *   We will use JSX to display a greeting message and the recipient's name inside a styled `div`.

*   **Section 5: Data Propagation (Props)**
    *   The `<GreetingCard>` will accept a `name` prop to personalize the message.

*   **Section 6: Managing the Internal State (`useState` Hook)**
    *   We will use `useState` to store the current greeting message (e.g., "Hello"). A button will allow the user to cycle through different greetings like "Welcome" or "Good Day".

**Step-by-Step Code:**

1.  **Create `src/components/GreetingCard.js`**
    ```javascript
    // src/components/GreetingCard.js
    import React, { useState } from 'react';

    // This component receives a 'name' prop
    function GreetingCard({ name }) {
      // useState to manage the current greeting. Initial value is 'Hello'.
      const [greeting, setGreeting] = useState('Hello');

      const changeGreeting = () => {
        // Simple logic to cycle through greetings
        if (greeting === 'Hello') {
          setGreeting('Welcome');
        } else if (greeting === 'Welcome') {
          setGreeting('Good Day');
        } else {
          setGreeting('Hello');
        }
      };

      return (
        <div className="greeting-card">
          {/* JSX displays the state variable 'greeting' and the prop 'name' */}
          <h2>{greeting}, {name}!</h2>
          <button onClick={changeGreeting}>Change Greeting</button>
        </div>
      );
    }

    export default GreetingCard;
    ```

2.  **Add Styling in `src/App.css`**
    ```css
    .greeting-card {
      border: 2px solid navy;
      border-radius: 10px;
      padding: 20px;
      margin: 20px;
      width: 300px;
      text-align: center;
      box-shadow: 0 4px 8px rgba(0,0,0,0.1);
    }
    ```

3.  **Update `src/App.js`**
    ```javascript
    // src/App.js
    import React from 'react';
    import GreetingCard from './components/GreetingCard';
    import './App.css';

    function App() {
      return (
        <div className="App">
          <h1>Greeting Card App</h1>
          {/* We pass 'Maria' down to the component as the 'name' prop */}
          <GreetingCard name="Maria" />
          <GreetingCard name="David" />
        </div>
      );
    }

    export default App;
    ```

---

### **App 3: Basic Image Gallery with a "Next" Button**

This app will display a single image from a list and allow the user to click a "Next" button to view the next image.

*   **Section 3: Creating Components & Designing UI**
    *   We will create a single component, `<ImageGallery>`.
    1.  Inside `/src/components`, create a file named `ImageGallery.js`.

*   **Section 4: Using JSX**
    *   JSX is used to render the `<img>` tag dynamically using a URL from an array. It will also display the current image number.

*   **Section 5: Data Propagation (Props)**
    *   The `<ImageGallery>` will receive an array of `images` (URLs) as a prop.

*   **Section 6: Managing the Internal State (`useState` Hook)**
    *   `useState` will hold the `currentIndex` of the image being displayed from the `images` array. Clicking "Next" will increment this index.

**Step-by-Step Code:**

1.  **Create `src/components/ImageGallery.js`**
    ```javascript
    // src/components/ImageGallery.js
    import React, { useState } from 'react';

    // This component receives an array of image URLs as 'images' prop
    function ImageGallery({ images }) {
      // useState to track which image is currently shown. Starts at index 0.
      const [currentIndex, setCurrentIndex] = useState(0);

      const showNextImage = () => {
        // Update state to the next index, looping back to 0 at the end
        setCurrentIndex((currentIndex + 1) % images.length);
      };

      return (
        <div className="image-gallery">
          <p>Image {currentIndex + 1} of {images.length}</p>
          {/* JSX uses the state 'currentIndex' to pick an image from the 'images' prop */}
          <img src={images[currentIndex]} alt="Gallery" width="400" />
          <div>
            <button onClick={showNextImage}>Next</button>
          </div>
        </div>
      );
    }

    export default ImageGallery;
    ```

2.  **Add Styling in `src/App.css`**
    ```css
    .image-gallery {
      text-align: center;
    }
    .image-gallery img {
      border: 5px solid #eee;
      margin-bottom: 10px;
    }
    ```

3.  **Update `src/App.js`**
    ```javascript
    // src/App.js
    import React from 'react';
    import ImageGallery from './components/ImageGallery';
    import './App.css';

    function App() {
      // An array of image URLs to be passed as props
      const imageUrls = [
        'https://picsum.photos/id/1018/400/300',
        'https://picsum.photos/id/1015/400/300',
        'https://picsum.photos/id/1025/400/300',
      ];

      return (
        <div className="App">
          <h1>Simple Image Gallery</h1>
          <ImageGallery images={imageUrls} />
        </div>
      );
    }

    export default App;
    ```

---

### **App 4: Character Stat Increaser**

This is a simple character profile where you can increase stats like "Strength" or "Magic" with buttons.

*   **Section 3: Creating Components & Designing UI**
    *   We will create a `<CharacterStats>` component.
    1.  Inside `/src/components`, create `CharacterStats.js`.

*   **Section 4: Using JSX**
    *   JSX will display the character's name (from props) and their stats (from state).

*   **Section 5: Data Propagation (Props)**
    *   The component will receive the character's `name` as a prop.

*   **Section 6: Managing the Internal State (`useState` Hook)**
    *   We'll use `useState` to manage an object of stats (`{ strength: 0, magic: 0 }`). Buttons will update the individual values within this state object.

**Step-by-Step Code:**

1.  **Create `src/components/CharacterStats.js`**
    ```javascript
    // src/components/CharacterStats.js
    import React, { useState } from 'react';

    // Component receives a 'name' prop
    function CharacterStats({ name }) {
      // useState to manage an object of character stats
      const [stats, setStats] = useState({ strength: 5, magic: 3 });

      const increaseStrength = () => {
        // To update an object in state, we create a new object
        setStats({ ...stats, strength: stats.strength + 1 });
      };

      const increaseMagic = () => {
        setStats({ ...stats, magic: stats.magic + 1 });
      };

      return (
        <div className="character-stats">
          <h2>{name}</h2>
          <p>Strength: {stats.strength}</p>
          <p>Magic: {stats.magic}</p>
          <button onClick={increaseStrength}>+1 Strength</button>
          <button onClick={increaseMagic}>+1 Magic</button>
        </div>
      );
    }

    export default CharacterStats;
    ```

2.  **Add Styling in `src/App.css`**
    ```css
    .character-stats {
      width: 250px;
      padding: 15px;
      border: 1px solid gray;
      border-radius: 8px;
      margin: 15px;
    }
    .character-stats button {
      margin-right: 10px;
    }
    ```

3.  **Update `src/App.js`**
    ```javascript
    // src/App.js
    import React from 'react';
    import CharacterStats from './components/CharacterStats';
    import './App.css';

    function App() {
      return (
        <div className="App">
          <h1>Character Sheet</h1>
          {/* We pass the character's name down as a prop */}
          <CharacterStats name="Gandalf" />
        </div>
      );
    }

    export default App;
    ```

---

### **App 5: Simple Font Size Changer**

This application will display some text with buttons to increase or decrease its font size.

*   **Section 3: Creating Components & Designing UI**
    *   We'll create one component, `<FontSizeChanger>`.
    1.  Inside `/src/components`, create `FontSizeChanger.js`.

*   **Section 4: Using JSX**
    *   We will use JSX to render a paragraph of text. Crucially, we'll use an inline style object `{}` to dynamically set the `fontSize`.

*   **Section 5: Data Propagation (Props)**
    *   The component will receive the `initialText` to be displayed as a prop.

*   **Section 6: Managing the Internal State (`useState` Hook)**
    *   A state variable (`fontSize`) will hold the current font size as a number. Buttons will update this state.

**Step-by-Step Code:**

1.  **Create `src/components/FontSizeChanger.js`**
    ```javascript
    // src/components/FontSizeChanger.js
    import React, { useState } from 'react';

    // Component receives 'initialText' prop
    function FontSizeChanger({ initialText }) {
      // useState to manage the font size number. Initial value is 16.
      const [fontSize, setFontSize] = useState(16);

      return (
        <div className="font-changer">
          {/* JSX uses an inline style object to apply the 'fontSize' state */}
          <p style={{ fontSize: `${fontSize}px` }}>
            {initialText}
          </p>
          <div>
            <button onClick={() => setFontSize(fontSize - 2)}>-</button>
            <span> Current Size: {fontSize}px </span>
            <button onClick={() => setFontSize(fontSize + 2)}>+</button>
          </div>
        </div>
      );
    }

    export default FontSizeChanger;
    ```

2.  **Add Styling in `src/App.css`**
    ```css
    .font-changer {
      padding: 20px;
      border: 1px solid black;
      margin: 20px;
    }
    ```

3.  **Update `src/App.js`**
    ```javascript
    // src/App.js
    import React from 'react';
    import FontSizeChanger from './components/FontSizeChanger';
    import './App.css';

    function App() {
      const text = "This text can be resized. Use the buttons below to make it bigger or smaller.";

      return (
        <div className="App">
          <h1>Font Size Adjuster</h1>
          {/* We pass the text down as a prop */}
          <FontSizeChanger initialText={text} />
        </div>
      );
    }

    export default App;
    ```