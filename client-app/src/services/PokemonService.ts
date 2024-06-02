import axios from 'axios';

const API_URL = 'https://localhost:7123';

export const getPokemonSummary = async () => {
  const response = await axios.get(`${API_URL}/summary`);
  return response.data;
};

export const getPokemonList = async (page: number, size: number) => {
  const response = await axios.get(`${API_URL}/pokemon?page=${page}&size=${size}`);
  return response.data;
};

export const getPokemonDetails = async (id: number) => {
  const response = await axios.get(`${API_URL}/pokemon/${id}`);
  return response.data;
};