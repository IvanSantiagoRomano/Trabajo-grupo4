// Hecho por Tobias Guzzo
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './Login.css';

export const Login = () => {
    const [usuario, setUsuario] = useState('');
    const [contrasena, setContrasena] = useState('');
    const navegar = useNavigate();

    const manejarEnvio = (e: React.FormEvent) => {
        e.preventDefault();
        navegar('/dashboard');
    };

    return (
        <div id="pantalla-login" className="contenedor-login">
            <div id="tarjeta-principal" className="tarjeta-login">
                <div className="contenedor-bandera">
                    <svg viewBox="0 0 900 600" xmlns="http://www.w3.org/2000/svg" className="bandera-argentina">
                        <rect width="900" height="600" fill="#75AADB"/>
                        <rect width="900" height="200" y="200" fill="#FFFFFF"/>
                        <circle cx="450" cy="300" r="45" fill="#FDB813"/>
                    </svg>
                </div>
                <h1 className="titulo-login">Bienvenido</h1>
                <p className="subtitulo-login">Ingresa tus credenciales para continuar</p>
                
                <form id="formulario-acceso" className="formulario" onSubmit={manejarEnvio}>
                    <div className="grupo-input">
                        <label htmlFor="entrada-usuario" className="etiqueta">Usuario</label>
                        <input 
                            id="entrada-usuario"
                            type="text" 
                            className="campo-texto" 
                            value={usuario}
                            onChange={(e) => setUsuario(e.target.value)}
                            required
                        />
                    </div>
                    
                    <div className="grupo-input">
                        <label htmlFor="entrada-contrasena" className="etiqueta">Contraseña</label>
                        <input 
                            id="entrada-contrasena"
                            type="password" 
                            className="campo-texto"
                            value={contrasena}
                            onChange={(e) => setContrasena(e.target.value)}
                            required
                        />
                    </div>
                    
                    <button id="boton-ingresar" type="submit" className="boton-primario">
                        Ingresar
                    </button>
                </form>
            </div>
        </div>
    );
};
