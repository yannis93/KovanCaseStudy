import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import {
  Form,
  FormFeedback,
  FormGroup,
  FormText,
  Label,
  Input,
  Button,
} from 'reactstrap';
import './Login.css';
import {
  ApolloClient,
  InMemoryCache,
  gql
} from "@apollo/client";

export function Login () {

  const navigate = useNavigate();

  function submitForm(e) {
    e.preventDefault();
    var data = new FormData(e.target)
    let formObject = Object.fromEntries(data.entries())

    const client = new ApolloClient({
      uri: 'https://localhost:7246/graphql/',
      cache: new InMemoryCache()
    });
      client
        .mutate({
            mutation: gql`
              mutation {
                userLogin(login: { password: "${formObject.password}", username: "${formObject.username}" })
              }
            `
        })
        .then(result => {
          localStorage.setItem('token', result.data.userLogin);
          navigate('/vehicle-list');
        });
    }
    return (
      <div className="login">
        <h2>Sign In</h2>
        <Form className="form" onSubmit={submitForm}>
          <FormGroup>
            <Label>Username</Label>
            <Input
              type="text"
              name="username"
              id="username"
              defaultValue="admin"
              autoComplete='false'
              placeholder="username"
            />
          </FormGroup>
          <FormGroup>
            <Label for="examplePassword">Password</Label>
            <Input
              type="password"
              name="password"
              id="password"
              defaultValue="admin"
              placeholder="********"
            />
          </FormGroup>
          <Button>Submit</Button>
        </Form>
      </div>
    );
  }
