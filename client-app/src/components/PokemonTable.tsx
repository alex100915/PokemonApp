import React from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Box,
  Pagination,
} from '@mui/material';
import { Pokemon } from '../types/pokemon';

interface PokemonTableProps {
  pokemonList: Pokemon[];
  setPage: (page: number) => void;
  currentPage: number;
  totalPages: number; // Add this prop to handle total pages for pagination
}

const PokemonTable: React.FC<PokemonTableProps> = ({ pokemonList, setPage, currentPage, totalPages }) => {
  const navigate = useNavigate();

  const handlePokemonClick = (number: number) => {
    const scrollPosition = window.scrollY;
    navigate(`/pokemon/${number}`, { state: { fromPage: currentPage, scrollPosition } });
  };

  const handlePageChange = (event: React.ChangeEvent<unknown>, value: number) => {
    setPage(value);
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
      <Box mt={3} mb={2} display="flex" justifyContent="center">
        <Pagination
          count={totalPages}
          page={currentPage}
          onChange={handlePageChange}
          color="primary"
        />
      </Box>
    </Box>
  );
};

export default PokemonTable;
