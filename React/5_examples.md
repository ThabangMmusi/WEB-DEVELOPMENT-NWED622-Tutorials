### **App 1: Simple Personal Blog Post Page**

This application will display a single blog post with an author's profile and an interactive "like" button.

*   **Section 1: What is React? (Component-Based Architecture)**
    *   We will break the UI into components:
        *   `<App>`: The main container.
        *   `<Header>`: The website's main title.
        *   `<BlogPost>`: Holds the author's info and the post content.
        *   `<AuthorProfile>`: Displays the author's picture and name.
        *   `<LikeButton>`: An interactive button to track likes.

*   **Section 2: How to Set Up a React-based Application**
    1.  **Open your terminal** and navigate to where you want to store your project.
    2.  Run `npx create-react-app personal-blog-post`
    3.  Run `cd personal-blog-post`
    4.  Run `npm start` to see the initial React page.

*   **Section 3 & 4: Creating Components & Using JSX**
    1.  Inside `/src`, create a `components` folder.
    2.  **`src/components/Header.js`**
        ```javascript
        import React from 'react';
        function Header() {
          return <h1>My Personal Blog</h1>;
        }
        export default Header;
        ```
    3.  **`src/components/AuthorProfile.js`**
        ```javascript
        import React from 'react';
        // This component uses JSX to embed variables from a 'user' object
        function AuthorProfile({ author }) {
          return (
            <div>
              <img src={author.avatar} alt={author.name} width="50" />
              <h4>By: {author.name}</h4>
            </div>
          );
        }
        export default AuthorProfile;
        ```

*   **Section 5 & 6 & 7: Props, State, and Events**
    1.  **`src/components/LikeButton.js`**
        ```javascript
        import React, { useState } from 'react';
        function LikeButton() {
          // useState to manage the number of likes
          const [likes, setLikes] = useState(0);
          // Event handler for the button click
          const handleLike = () => {
            setLikes(likes + 1);
          };
          return (
            <div>
              <button onClick={handleLike}>Like</button>
              <p>{likes} likes</p>
            </div>
          );
        }
        export default LikeButton;
        ```
    2.  **`src/components/BlogPost.js`**
        ```javascript
        import React from 'react';
        import AuthorProfile from './AuthorProfile';
        import LikeButton from './LikeButton';
        // This component receives post data via props
        function BlogPost({ post }) {
          return (
            <article>
              <h2>{post.title}</h2>
              <AuthorProfile author={post.author} />
              <p>{post.content}</p>
              <LikeButton />
            </article>
          );
        }
        export default BlogPost;
        ```

*   **Section 8: Component Lifecycle (`useEffect`)**
    1.  **Update `src/App.js` to bring it all together and use `useEffect`.**
        ```javascript
        import React, { useEffect } from 'react';
        import Header from './components/Header';
        import BlogPost from './components/BlogPost';
        import './App.css';

        function App() {
          const blogPostData = {
            title: 'My First Day with React',
            content: 'I learned about components, props, and state. It was awesome!',
            author: {
              name: 'Chris Coder',
              avatar: 'https://i.pravatar.cc/150?u=chris'
            }
          };

          // useEffect to perform a side effect when the component mounts
          useEffect(() => {
            document.title = `Reading: ${blogPostData.title}`;
          }, []); // Empty array means this runs only once

          return (
            <div className="App">
              <Header />
              <main>
                <BlogPost post={blogPostData} />
              </main>
            </div>
          );
        }
        export default App;
        ```

---

### **App 2: Basic To-Do List**

A classic to-do list where you can add new items and see them appear on the screen.

*   **Section 1: What is React? (Component-Based Architecture)**
    *   `<App>`: The main container.
    *   `<TodoForm>`: An input field and button to add new to-dos.
    *   `<TodoList>`: Renders the list of all to-do items.

*   **Section 2: How to Set Up a React-based Application**
    1.  Run `npx create-react-app simple-todo-list`
    2.  Run `cd simple-todo-list`
    3.  Run `npm start`

*   **Section 3, 4, 6 & 7: Creating Components, JSX, State, and Events**
    1.  Create a `/src/components` folder.
    2.  **`src/components/TodoForm.js`**
        ```javascript
        import React, { useState } from 'react';
        // This component uses state for the input and events for submission
        function TodoForm({ addTodo }) {
          const [inputValue, setInputValue] = useState('');

          const handleSubmit = (event) => {
            event.preventDefault(); // Prevents page refresh
            if (!inputValue) return;
            addTodo(inputValue);
            setInputValue(''); // Clear input after submission
          };

          return (
            <form onSubmit={handleSubmit}>
              <input
                type="text"
                value={inputValue}
                onChange={(e) => setInputValue(e.target.value)}
                placeholder="Add a new to-do"
              />
              <button type="submit">Add</button>
            </form>
          );
        }
        export default TodoForm;
        ```    3.  **`src/components/TodoList.js`**
        ```javascript
        import React from 'react';
        // This component receives the list of todos via props and maps over them
        function TodoList({ todos }) {
          return (
            <ul>
              {todos.map((todo, index) => (
                <li key={index}>{todo}</li>
              ))}
            </ul>
          );
        }
        export default TodoList;
        ```

*   **Section 5 & 8: Props & Component Lifecycle (`useEffect`)**
    1.  **Update `src/App.js` to manage the overall state.**
        ```javascript
        import React, { useState, useEffect } from 'react';
        import TodoForm from './components/TodoForm';
        import TodoList from './components/TodoList';
        import './App.css';

        function App() {
          // State to hold all the to-do items
          const [todos, setTodos] = useState(['Learn React', 'Build an App']);

          const addTodo = (text) => {
            setTodos([...todos, text]);
          };

          // useEffect to log a message every time the todos list is updated
          useEffect(() => {
            console.log('Todo list has been updated!');
          }, [todos]); // Dependency array [todos] means this runs when 'todos' changes

          return (
            <div className="App">
              <h1>My To-Do List</h1>
              <TodoForm addTodo={addTodo} />
              <TodoList todos={todos} />
            </div>
          );
        }
        export default App;
        ```

---

### **App 3: Simple Product Page with a Quantity Counter**

This application displays a product with a button to increase the quantity before adding to a cart.

*   **Section 1: What is React? (Component-Based Architecture)**
    *   `<App>`: The main container.
    *   `<ProductDisplay>`: Shows the product image and details.
    *   `<QuantityCounter>`: Buttons to increase or decrease the quantity.

*   **Section 2: How to Set Up a React-based Application**
    1.  Run `npx create-react-app product-page`
    2.  Run `cd product-page`
    3.  Run `npm start`

*   **Section 3, 4, 6 & 7: Creating Components, JSX, State, and Events**
    1.  Create a `/src/components` folder.
    2.  **`src/components/QuantityCounter.js`**
        ```javascript
        import React, { useState } from 'react';
        function QuantityCounter() {
          const [quantity, setQuantity] = useState(1);

          return (
            <div>
              <button onClick={() => setQuantity(quantity > 1 ? quantity - 1 : 1)}>-</button>
              <span> {quantity} </span>
              <button onClick={() => setQuantity(quantity + 1)}>+</button>
              <p>Total items: {quantity}</p>
            </div>
          );
        }
        export default QuantityCounter;
        ```
    3.  **`src/components/ProductDisplay.js`**
        ```javascript
        import React from 'react';
        // This component receives product data via props
        function ProductDisplay({ product }) {
          return (
            <div>
              <img src={product.imageUrl} alt={product.name} width="200" />
              <h3>{product.name}</h3>
              <p>${product.price.toFixed(2)}</p>
            </div>
          );
        }
        export default ProductDisplay;
        ```

*   **Section 5 & 8: Props & Component Lifecycle (`useEffect`)**
    1.  **Update `src/App.js` to manage the application.**
        ```javascript
        import React, { useEffect } from 'react';
        import ProductDisplay from './components/ProductDisplay';
        import QuantityCounter from './components/QuantityCounter';
        import './App.css';

        function App() {
          const productData = {
            name: 'React T-Shirt',
            price: 24.99,
            imageUrl: 'https://via.placeholder.com/200'
          };

          // useEffect to perform a side effect when the component mounts
          useEffect(() => {
            alert('Welcome to our product page!');
          }, []); // Empty array ensures this runs only once on mount

          return (
            <div className="App">
              <h1>Product Details</h1>
              <ProductDisplay product={productData} />
              <QuantityCounter />
            </div>
          );
        }
        export default App;
        ```

---

### **App 4: Character Profile Card from an API**

This application will fetch a single character's data from a public API and display it.

*   **Section 1: What is React? (Component-Based Architecture)**
    *   `<App>`: The main container.
    *   `<CharacterCard>`: Displays the fetched character's data.

*   **Section 2: How to Set Up a React-based Application**
    1.  Run `npx create-react-app api-profile-card`
    2.  Run `cd api-profile-card`
    3.  Run `npm start`

*   **Section 3, 4, 5, 6, 7 & 8: All Steps Combined**
    1.  Create a `/src/components` folder.
    2.  **`src/components/CharacterCard.js`**
        ```javascript
        import React from 'react';
        // This component receives the character data via props
        function CharacterCard({ character }) {
          if (!character) {
            return <p>Loading character...</p>;
          }
          return (
            <div className="character-card">
              <img src={character.image} alt={character.name} />
              <h2>{character.name}</h2>
              <p>Status: {character.status}</p>
              <p>Species: {character.species}</p>
            </div>
          );
        }
        export default CharacterCard;
        ```
    3.  **Update `src/App.js` to fetch data and manage state.**
        ```javascript
        import React, { useState, useEffect } from 'react';
        import CharacterCard from './components/CharacterCard';
        import './App.css';

        function App() {
          // State to hold the character data from the API
          const [character, setCharacter] = useState(null);

          // useEffect to fetch data from the API when the component mounts
          useEffect(() => {
            fetch('https://rickandmortyapi.com/api/character/1') // Fetch Rick Sanchez
              .then(response => response.json())
              .then(data => {
                setCharacter(data); // Update state with the fetched data
              });
          }, []); // Empty array means this runs only once

          return (
            <div className="App">
              <h1>Rick and Morty Character</h1>
              <CharacterCard character={character} />
            </div>
          );
        }
        export default App;
        ```

---

### **App 5: Simple Light/Dark Mode Toggler**

A page with a button that toggles the background color between light and dark themes.

*   **Section 1: What is React? (Component-Based Architecture)**
    *   `<App>`: The main container that manages the theme.
    *   `<ThemeToggler>`: A button to switch the theme.
    *   `<Content>`: Some sample text to show the theme change.

*   **Section 2: How to Set Up a React-based Application**
    1.  Run `npx create-react-app theme-toggler`
    2.  Run `cd theme-toggler`
    3.  Run `npm start`

*   **Section 3, 4, 5, 6 & 7: Components, JSX, Props, State, Events**
    1.  Create a `/src/components` folder.
    2.  **`src/components/ThemeToggler.js`**
        ```javascript
        import React from 'react';
        // This component receives the toggle function via props
        function ThemeToggler({ toggleTheme }) {
          return <button onClick={toggleTheme}>Toggle Theme</button>;
        }
        export default ThemeToggler;
        ```
    3.  **`src/components/Content.js`**
        ```javascript
        import React from 'react';
        function Content() {
          return <p>This is some content on the page that will change color!</p>;
        }
        export default Content;
        ```

*   **Section 8: Component Lifecycle (`useEffect`)**
    1.  **Update `src/App.js` to manage the theme state.**
        ```javascript
        import React, { useState, useEffect } from 'react';
        import ThemeToggler from './components/ThemeToggler';
        import Content from './components/Content';
        import './App.css';

        function App() {
          // State to manage the current theme ('light' or 'dark')
          const [theme, setTheme] = useState('light');

          // Event handler to toggle the theme
          const toggleTheme = () => {
            setTheme(theme === 'light' ? 'dark' : 'light');
          };

          // useEffect to update the body's class when the theme state changes
          useEffect(() => {
            document.body.className = theme; // Set body class to 'light' or 'dark'
            console.log(`Theme changed to: ${theme}`);
          }, [theme]); // Dependency array [theme] makes this run whenever theme changes

          return (
            <div className="App">
              <h1>Light/Dark Mode</h1>
              <ThemeToggler toggleTheme={toggleTheme} />
              <Content />
            </div>
          );
        }
        export default App;
        ```
    2.  **Add CSS to `src/App.css` to handle the theme change:**
        ```css
        body.light {
          background-color: #ffffff;
          color: #000000;
        }

        body.dark {
          background-color: #282c34;
          color: #ffffff;
        }

        .App {
          text-align: center;
          padding-top: 50px;
        }
        ```