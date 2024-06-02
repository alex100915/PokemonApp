import React, { useEffect, useState } from 'react';
import { useLocation } from 'react-router-dom';
import { getPokemonList } from '../services/PokemonService';
import PokemonTable from '../components/PokemonTable';
import { Container, Typography, Box, CircularProgress, Backdrop, CssBaseline, Paper } from '@mui/material';
import { useSummary } from '../contexts/SummaryContext';
import SummarySection from '../components/SummarySection';
import { Pokemon } from '../types/pokemon';

const DashboardPage: React.FC = () => {
  const location = useLocation();
  const { summary, loading: summaryLoading } = useSummary();
  const [pokemonList, setPokemonList] = useState<Pokemon[]>([]);
  const [page, setPage] = useState(location.state?.fromPage || 1);
  const [loading, setLoading] = useState(true);
  const scrollPosition = location.state?.scrollPosition || 0;

  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
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
      <CssBaseline />
      <Backdrop open={loading || summaryLoading} style={{ zIndex: 1000 }}>
        <CircularProgress color="inherit" />
      </Backdrop>
      <Box mt={4} mb={4}>
        <Typography variant="h4" gutterBottom align="center">
          Pokémon Dashboard
        </Typography>
        {summary && (
          <Box mb={2}>
            <SummarySection summary={summary}/>
          </Box>
        )}
        <Paper elevation={3} style={{ padding: '16px', marginBottom: '16px' }}>
          <PokemonTable pokemonList={pokemonList} setPage={setPage} currentPage={page} />
        </Paper>
      </Box>
    </Container>
  );
};

export default DashboardPage;
