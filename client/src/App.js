import React from "react";
import {
  BrowserRouter as Router,
  Routes,
  Route,
  Link
} from "react-router-dom";
import {Login} from "./pages/login/Login";
import 'bootstrap/dist/css/bootstrap.min.css';
import VehicleList from "./pages/vehicle/VehicleList";
import { Container, Row } from "reactstrap";
import './App.css';

export default function App() {
  return (
    <Router>
      <Container className="app-container">
          <Routes>
            <Route path="/login" element={<Login/>} />
            <Route path="/vehicle-list" element={<VehicleList/>} />
            <Route path="/" element={<Login  />} />
		  </Routes>
      </Container>
    </Router>
  );
}