import React, { useEffect, useState } from 'react';
import { useParams, useLocation, useNavigate } from 'react-router-dom';
import { getPokemonDetails, getPokemonByName } from '../services/PokemonService';
import { Container, Typography, Box, CircularProgress, Paper, Grid, Button, Link as MuiLink, Backdrop } from '@mui/material';
import { Pokemon } from '../types/pokemon';

const DetailsPage: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();
  const location = useLocation();
  const fromPage = location.state?.fromPage || 1;

  const [pokemon, setPokemon] = useState<Pokemon>();
  const [loading, setLoading] = useState(true);

  const fetchPokemon = async (pokemonId: number) => {
    setLoading(true);
    const data = await getPokemonDetails(pokemonId);
    setPokemon(data);
    setLoading(false);
  };

  useEffect(() => {
    fetchPokemon(Number(id));
  }, [id]);

  const handleEvolutionClick = async (name: string) => {
    setLoading(true);
    const data = await getPokemonByName(name);
    navigate(`/pokemon/${data.number}`, { state: { fromPage, scrollPosition: window.scrollY } });
  };

  const handleBackClick = () => {
    const scrollPosition = location.state?.scrollPosition || 0;
    navigate("/", { state: { fromPage, scrollPosition } });
  };

  if (loading) 
    return (
      <Backdrop open={loading} style={{ zIndex: 1000 }}>
        <CircularProgress color="inherit" />
      </Backdrop>
    );

  if (!pokemon) {
    return <Typography variant="h6" align="center">Pokemon not found</Typography>;
  }

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
                <img src={pokemon.image} alt={pokemon.name} style={{ maxWidth: '100%', height: '300px' }} />
              </Grid>
              <Grid item xs={12} sm={6}>
                <Typography variant="body1" gutterBottom><strong>Number:</strong> {pokemon.number}</Typography>
                <Typography variant="body1" gutterBottom><strong>Generation:</strong> {pokemon.generation}</Typography>
                <Typography variant="body1" gutterBottom><strong>Height:</strong> {pokemon.height}</Typography>
                <Typography variant="body1" gutterBottom><strong>Weight:</strong> {pokemon.weight}</Typography>
                <Typography variant="body1" gutterBottom><strong>Types:</strong> {pokemon.types.join(', ')}</Typography>
                <Typography variant="body1" gutterBottom><strong>Abilities:</strong> {pokemon.abilities.join(', ')}</Typography>
                <Typography variant="body1" gutterBottom><strong>Moves:</strong> {pokemon.moves.join(', ')}</Typography>
                <Typography variant="body1" gutterBottom>
                  <strong>Evolution From: </strong> 
                  {pokemon.evolution.from ? ( pokemon.evolution.from.toLowerCase() === pokemon.name.toLowerCase() ? pokemon.evolution.from :   
                    <MuiLink href="#" onClick={(e) => { e.preventDefault(); handleEvolutionClick(pokemon.evolution.from!); }}>
                      {pokemon.evolution.from}
                    </MuiLink>
                  ) : (
                    "None"
                  )}
                </Typography>
                <Typography variant="body1" gutterBottom>
                <strong>Evolution To: </strong>
                  {pokemon.evolution.to.length > 0 ? (
                    pokemon.evolution.to.map((evol: string, index: number) => (
                      evol.toLowerCase() === pokemon.name.toLowerCase() ? (
                        evol
                      ) : (
                        <MuiLink key={index} href="#" onClick={(e) => { e.preventDefault(); handleEvolutionClick(evol); }} style={{ marginLeft: index > 0 ? '8px' : '0' }}>
                          {evol}
                        </MuiLink>
                      )
                    ))
                  ) : (
                    "None"
                  )}
                </Typography>
              </Grid>
            </Grid>
          </Box>
        </Paper>
      </Box>
    </Container>
  );
};

export default DetailsPage;
