import React, { createContext, useContext, useState, useEffect, ReactNode } from 'react';
import { getPokemonSummary } from '../services/PokemonService';
import { SummaryData } from "../types/summary";

interface SummaryContextProps {
  summary: SummaryData | null;
  loading: boolean;
}

const SummaryContext = createContext<SummaryContextProps | null>(null);

export const useSummary = () => {
  const context = useContext(SummaryContext);
  if (!context) {
    throw new Error('useSummary must be used within a SummaryProvider');
  }
  return context;
};

interface SummaryProviderProps {
  children: ReactNode;
}

export const SummaryProvider: React.FC<SummaryProviderProps> = ({ children }) => {
  const [summary, setSummary] = useState<SummaryData | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchSummary = async () => {
      try {
        const data = await getPokemonSummary();
        setSummary(data);
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
