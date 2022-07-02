import { ApolloClient, InMemoryCache } from '@apollo/client'

export const client = new ApolloClient({
  uri: process.env.REACT_APP_URI,
  headers: {
    Authorization: `Bearer ${process.env.REACT_APP_API_ACCESS_TOKEN}`
  },
  cache: new InMemoryCache()
})
