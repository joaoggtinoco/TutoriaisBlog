import axios from 'axios'

export const api = axios.create({
  // o endereço base do nosso back-end
  baseURL: 'http://54.207.212.51:7276'
})