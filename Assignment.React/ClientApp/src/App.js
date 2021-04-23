import { BrowserRouter as Router } from "react-router-dom";
import Navigation from "./components/Navigation";
import PageLayout from './components/PageLayout.js';
import Routes from './route.js';
import React from 'react';

function App() {
  return (
    <Router>
      <PageLayout header={<Navigation />} content={<Routes/>}></PageLayout>
    </Router>
  );
}

export default App;