import axios from 'axios';

const API_URL = 'https://localhost:7123/pokemon/';

export const getPokemonSummary = async () => {
  const response = await axios.get(`${API_URL}summary`);
  return response.data;
};

export const getPokemonList = async (page: number, size: number) => {
  const response = await axios.get(`${API_URL}?page=${page}&size=${size}`);
  return response.data;
};

export const getPokemonDetails = async (id: number) => {
  const response = await axios.get(`${API_URL}${id}`);
  return response.data;
};

export const getPokemonByName = async (name: string) => {
  const response = await axios.get(`${API_URL}name/${name}`);
  return response.data;
};