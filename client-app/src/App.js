import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Dashboard from './components/Dashboard';
import PokemonDetails from './components/PokemonDetails';

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Dashboard />} />
        <Route path="/pokemon/:number" element={<PokemonDetails />} />
      </Routes>
    </Router>
  );
};

export default App;