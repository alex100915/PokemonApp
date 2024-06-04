import axios from 'axios';
import { Pokemon } from '../types/pokemon';
import { PokemonSummaryData } from '../types/summary';

const API_URL = 'https://localhost:7123/pokemon/';

export const getPokemonSummary = async () => {
  const response = await axios.get<PokemonSummaryData>(`${API_URL}summary`);
  return response.data;
};

export const getPokemonList = async () => {
  const response = await axios.get<Pokemon[]>(`${API_URL}`);
  return response.data;
};

export const getPokemonDetails = async (id: number) => {
  const response = await axios.get<Pokemon>(`${API_URL}${id}`);
  return response.data;
};

export const getPokemonByName = async (name: string) => {
  const response = await axios.get<Pokemon>(`${API_URL}name/${name}`);
  return response.data;
};