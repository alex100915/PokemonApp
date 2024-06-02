import React, { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';
import { getPokemonSummary, getPokemonList } from '../services/PokemonService';
import PokemonTable from '../components/PokemonTable';
import { Container, Typography, Box, CircularProgress, Backdrop } from '@mui/material';

const DashboardPage: React.FC = () => {
  const location = useLocation();
  const [summary, setSummary] = useState<any>(null);
  const [pokemonList, setPokemonList] = useState<any[]>([]);
  const [page, setPage] = useState(location.state?.fromPage || 1);
  const [loading, setLoading] = useState(true);
  const scrollPosition = location.state?.scrollPosition || 0;

  useEffect(() => {
    const fetchData = async () => {
      const summaryData = await getPokemonSummary();
      setSummary(summaryData);
      const listData = await getPokemonList(page, 25);
      setPokemonList(listData);
      setLoading(false);
    };
    fetchData();
  }, [page]);

  useEffect(() => {
    if (!loading) {
      window.scrollTo(0, scrollPosition);
    }
  }, [loading, scrollPosition]);

  return (
    <Container>
      <Backdrop open={loading} style={{ zIndex: 1000 }}>
        <CircularProgress color="inherit" />
      </Backdrop>
      <Box mt={4}>
        <Typography variant="h4" gutterBottom>
          Pokemon Dashboard
        </Typography>
        {summary && (
          <Box mb={4}>
            <Typography variant="h6">Total Pokemon Species: {summary.total}</Typography>
            <Typography variant="body1">Types Count: {JSON.stringify(summary.types)}</Typography>
            <Typography variant="body1">Generations Count: {JSON.stringify(summary.generations)}</Typography>
          </Box>
        )}
        <PokemonTable pokemonList={pokemonList} setPage={setPage} currentPage={page} />
      </Box>
    </Container>
  );
};

export default DashboardPage;
