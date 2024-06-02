import React, { createContext, useContext, useState, useEffect, ReactNode } from 'react';
import { getPokemonSummary } from '../services/PokemonService';

const SummaryContext = createContext<any>(null);

export const useSummary = () => useContext(SummaryContext);

interface SummaryProviderProps {
  children: ReactNode;
}

export const SummaryProvider: React.FC<SummaryProviderProps> = ({ children }) => {
  const [summary, setSummary] = useState<any>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchSummary = async () => {
      try {
        const data = await getPokemonSummary();
        setSummary(data);
        console.log(data)
      } catch (error) {
        console.error('Failed to fetch summary:', error);
      } finally {
        setLoading(false);
      }
    };

    fetchSummary();
  }, []);

  return (
    <SummaryContext.Provider value={{ summary, loading }}>
      {children}
    </SummaryContext.Provider>
  );
};
