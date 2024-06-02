import React, { useEffect, useState } from 'react';
import { getPokemonSummary, getPokemonList } from '../services/PokemonService';
import PokemonTable from '../components/PokemonTable';
import { Container, Typography, Box, CircularProgress } from '@mui/material';

const DashboardPage: React.FC = () => {
  const [summary, setSummary] = useState<any>(null);
  const [pokemonList, setPokemonList] = useState<any[]>([]);
  const [page, setPage] = useState(1);
  const [loading, setLoading] = useState(true);

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

  if (loading) return <CircularProgress />;

  return (
    <Container>
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
        <PokemonTable pokemonList={pokemonList} setPage={setPage} />
      </Box>
    </Container>
  );
};

export default DashboardPage;
