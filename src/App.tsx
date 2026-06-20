// Hecho por Tobias Guzzo
import React from 'react';
import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import { VehicleDashboard } from './features/vehicles/VehicleDashboard';
import { Login } from './features/auth/Login';
import './App.css';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/login" element={<Login />} />
        <Route path="/dashboard" element={<VehicleDashboard />} />
        
        {/* Cualquier otra ruta redirige automáticamente al login */}
        <Route path="*" element={<Navigate to="/login" replace />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
