import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Button,
  Box,
} from '@mui/material';
import { Pokemon } from '../types/pokemon';

interface PokemonTableProps {
  pokemonList: Pokemon[];
  setPage: React.Dispatch<React.SetStateAction<number>>;
  currentPage: number;
}

const PokemonTable: React.FC<PokemonTableProps> = ({ pokemonList, setPage, currentPage }) => {
  const navigate = useNavigate();

  const handlePokemonClick = (number: number) => {
    const scrollPosition = window.scrollY;
    navigate(`/pokemon/${number}`, { state: { fromPage: currentPage, scrollPosition } });
  };

  return (
    <Box mt={2}>
      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Number</TableCell>
              <TableCell>Name</TableCell>
              <TableCell>Generation</TableCell>
              <TableCell>Height</TableCell>
              <TableCell>Weight</TableCell>
              <TableCell>Type 1</TableCell>
              <TableCell>Type 2</TableCell>
              <TableCell>Moves Count</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {pokemonList.map((pokemon) => (
              <TableRow key={pokemon.number} style={{ cursor: 'pointer' }} onClick={() => handlePokemonClick(pokemon.number)}>
                <TableCell>{pokemon.number}</TableCell>
                <TableCell>
                  <Link to="#" onClick={(e) => { e.preventDefault(); handlePokemonClick(pokemon.number); }}>
                    {pokemon.name}
                  </Link>
                </TableCell>
                <TableCell>{pokemon.generation}</TableCell>
                <TableCell>{pokemon.height}</TableCell>
                <TableCell>{pokemon.weight}</TableCell>
                <TableCell>{pokemon.types[0]}</TableCell>
                <TableCell>{pokemon.types[1]}</TableCell>
                <TableCell>{pokemon.moves.length}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      <Box mt={3} mb={2} display="flex" justifyContent="space-between">
        <Button variant="contained" color="primary" onClick={() => setPage((prevPage) => Math.max(prevPage - 1, 1))}>
          Previous
        </Button>
        <Button variant="contained" color="primary" onClick={() => setPage((prevPage) => prevPage + 1)}>
          Next
        </Button>
      </Box>
    </Box>
  );
};

export default PokemonTable;
