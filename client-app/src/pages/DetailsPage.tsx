import React, { useEffect, useState } from 'react';
import { useParams, useLocation, useNavigate } from 'react-router-dom';
import { getPokemonDetails } from '../services/PokemonService';
import { Container, Typography, Box, CircularProgress, Paper, Grid, Button } from '@mui/material';

const DetailsPage: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();
  const location = useLocation();
  const fromPage = location.state?.fromPage || 1;

  const [pokemon, setPokemon] = useState<any>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchData = async () => {
      const data = await getPokemonDetails(Number(id));
      setPokemon(data);
      setLoading(false);
    };
    fetchData();
  }, [id]);

  if (loading) return <CircularProgress />;

  const handleBackClick = () => {
    const scrollPosition = location.state?.scrollPosition || 0;
    navigate("/", { state: { fromPage, scrollPosition } });
  };

  return (
    <Container>
      <Box mt={4}>
        <Button
          variant="contained"
          color="primary"
          onClick={handleBackClick}
          style={{ marginBottom: '16px' }}
        >
          Back
        </Button>
        <Typography variant="h4" gutterBottom>
          {pokemon.name}
        </Typography>
        <Paper elevation={3}>
          <Box p={4}>
            <Grid container spacing={3}>
              <Grid item xs={12} sm={6}>
                <img src={pokemon.image} alt={pokemon.name} style={{ height:'300px', maxWidth: '100%' }} />
              </Grid>
              <Grid item xs={12} sm={6}>
                <Typography variant="body1" gutterBottom><strong>Number:</strong> {pokemon.number}</Typography>
                <Typography variant="body1" gutterBottom><strong>Generation:</strong> {pokemon.generation}</Typography>
                <Typography variant="body1" gutterBottom><strong>Height:</strong> {pokemon.height}</Typography>
                <Typography variant="body1" gutterBottom><strong>Weight:</strong> {pokemon.weight}</Typography>
                <Typography variant="body1" gutterBottom><strong>Types:</strong> {pokemon.types.join(', ')}</Typography>
                <Typography variant="body1" gutterBottom><strong>Abilities:</strong> {pokemon.abilities.join(', ')}</Typography>
                <Typography variant="body1" gutterBottom><strong>Moves:</strong> {pokemon.moves.join(', ')}</Typography>
                <Typography variant="body1" gutterBottom><strong>Evolution From:</strong> {pokemon.evolution.from}</Typography>
                <Typography variant="body1" gutterBottom><strong>Evolution To:</strong> {pokemon.evolution.to.join(', ')}</Typography>
              </Grid>
            </Grid>
          </Box>
        </Paper>
      </Box>
    </Container>
  );
};

export default DetailsPage;
