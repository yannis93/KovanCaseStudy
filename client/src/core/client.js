import { ApolloClient, HttpLink, ApolloLink, InMemoryCache, from } from '@apollo/client';
// import { onError } from '@apollo/client/link/error';
import {APP_CONFIG} from './enviroment';
const httpLink = new HttpLink({ uri: APP_CONFIG.developmentUrl + '/graphql' });

const authMiddleware = new ApolloLink((operation, forward) => {
  // add the authorization to the headers
  operation.setContext(({ headers = {} }) => ({
    headers: {
      ...headers,
      authorization: "Bearer " + localStorage.getItem('token'),
    }
  }));

  return forward(operation);
})

const client = new ApolloClient({
  cache: new InMemoryCache(),
  link: from([
    authMiddleware,
    httpLink
  ]),
});

export default client;