import axios from 'axios'

export const api = axios.create({
  // o endereço base do nosso back-end
  baseURL: 'https://localhost:7276'
})