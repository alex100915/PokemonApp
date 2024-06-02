import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import DashboardPage from './pages/DashboardPage';
import DetailsPage from './pages/DetailsPage';
import { CssBaseline } from '@mui/material';
import { SummaryProvider } from './contexts/SummaryContext';

const App: React.FC = () => {
  return (
    <SummaryProvider>
      <Router>
        <CssBaseline />
        <Routes>
          <Route path="/" element={<DashboardPage />} />
          <Route path="/pokemon/:id" element={<DetailsPage />} />
        </Routes>
      </Router>
    </SummaryProvider>
  );
};

export default App;
