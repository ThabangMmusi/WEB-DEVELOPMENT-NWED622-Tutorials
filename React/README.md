<p align="center">
  <img src="./resources/React-icon.svg" alt="React Logo" width="250" />
</p>

# React

## What is React?

React (also known as React.js or ReactJS) is a free and open-source JavaScript library, often referred to as a frontend framework, for building user interfaces (UIs). It was developed by Jordan Walke, a software engineer at Meta (formerly Facebook), and is now maintained by Meta and a community of individual developers and companies.

React is used to build single-page applications and allows developers to create reusable UI components. It uses a component-based architecture, where the UI is broken down into smaller, reusable pieces. These components are written using JSX, a syntax extension for JavaScript that allows developers to write HTML-like code directly within their JavaScript.

To improve performance, React uses a virtual DOM (Document Object Model). Instead of directly manipulating the browser's DOM, which can be slow, React creates an in-memory copy. When a component's data changes, React updates the virtual DOM first, calculates the most efficient way to make the changes, and then updates the actual browser DOM with only what has changed. This process, called reconciliation, leads to faster rendering and a smoother user experience.



## History of React

React was created by Jordan Walke, a software engineer at Facebook, in 2011. It was initially called "FaxJS" and was first deployed on Facebook's News Feed in 2011 and later on Instagram in 2012. Facebook open-sourced React in May 2013.

Major milestones in React's history include:

*   **React Native (2015):** Extended React to mobile app development.
*   **React Fiber (2017):** A rewrite of React's core algorithm for better performance.
*   **React Hooks (2019):** Introduced a new way to write components and manage state.

## React in the Industry

React is one of the most popular JavaScript libraries for frontend development. Here are some statistics that show its usage in the industry:

*   **Website Usage:** As of 2023, React is used by over 13.4 million live websites.
*   **Developer Popularity:** According to a 2024 Stack Overflow survey, 41.6% of professional developers use ReactJS.
*   **Download Trends:** The React core package on NPM records over 20 million weekly downloads as of September 2024.
*   **Job Market:** The demand for React developers is high, with over 60,000 job listings globally mentioning React as a required skill in October 2023.

React's flexibility, performance, and strong community support have led to its adoption by major companies like Netflix, Instagram, and Uber.

## Getting Started with React

### Create React App (The classic approach)

Before Vite, `create-react-app` was the most popular way to create a new React application. It is still a valid way to create a React app, but it is no longer officially recommended by the React team.

To create a new React app using `create-react-app`, run the following command:

```bash
npx create-react-app my-app
```

This will create a new directory called `my-app` with a React project inside. You can then navigate into the directory and start the development server:

```bash
cd my-app
npm start
```

### Other Build Tools and Frameworks

Besides Vite and Create React App, there are other tools and frameworks you can use to build React applications:

*   **Parcel:** A web application bundler that is known for its developer-friendly, zero-configuration setup.
*   **Next.js:** A popular and powerful React framework for building production-ready applications. It offers features like server-side rendering and static site generation.
*   **Gatsby:** A static site generator that excels at creating fast, content-rich websites.
*   **Astro:** A modern web framework designed for building content-focused websites with a strong emphasis on performance.