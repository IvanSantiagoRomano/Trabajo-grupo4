// ==========================================
// COMPONENTE DE LOGIN (Frontend)
// ==========================================
// Hecho por Tobias Guzzo
// Este componente maneja la interfaz de usuario para el ingreso al sistema,
// y se conecta al backend utilizando nuestro servicio optimizado `userService`.

import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { userService } from '../../services/userService';
import './Login.css';

export const Login = () => {
    // ---------------------------------------------------------
    // 1. ESTADOS LOCALES
    // ---------------------------------------------------------
    const [usuario, setUsuario] = useState('');
    const [contrasena, setContrasena] = useState('');
    const [error, setError] = useState<string | null>(null);
    const [cargando, setCargando] = useState(false);
    
    // Herramienta de React Router para cambiar de página
    const navegar = useNavigate();

    // ---------------------------------------------------------
    // 2. FUNCIÓN DE INGRESO (Conexión al Backend)
    // ---------------------------------------------------------
    const manejarEnvio = async (e: React.FormEvent) => {
        e.preventDefault(); // Evita que la página se recargue al enviar el formulario
        
        // Reiniciamos los estados visuales (borramos errores viejos y ponemos modo carga)
        setError(null);
        setCargando(true);

        try {
            // Llamamos a nuestro servicio de API que conecta con el backend
            const datos = await userService.login(usuario, contrasena);
            console.log("Ingreso exitoso", datos);
            
            // Si el backend devuelve un token JWT, lo guardaríamos aquí para mantener la sesión:
            // localStorage.setItem('token', datos.token);

            // Redirigimos al panel principal una vez autenticado correctamente
            navegar('/dashboard');
        } catch (err: any) {
            // Si ocurre un error (ej. contraseña incorrecta), lo mostramos en pantalla
            setError(err.message || 'Error al iniciar sesión. Verifica tus credenciales.');
        } finally {
            // Terminamos el estado de carga para rehabilitar los botones
            setCargando(false);
        }
    };

    // ---------------------------------------------------------
    // 3. INTERFAZ GRÁFICA (UI)
    // ---------------------------------------------------------
    return (
        <div id="pantalla-login" className="contenedor-login">
            <div id="tarjeta-principal" className="tarjeta-login">
                
                {/* Decoración Visual: Bandera Argentina */}
                <div className="contenedor-bandera">
                    <svg viewBox="0 0 900 600" xmlns="http://www.w3.org/2000/svg" className="bandera-argentina">
                        <rect width="900" height="600" fill="#75AADB"/>
                        <rect width="900" height="200" y="200" fill="#FFFFFF"/>
                        <circle cx="450" cy="300" r="45" fill="#FDB813"/>
                    </svg>
                </div>
                
                <h1 className="titulo-login">Bienvenido</h1>
                <p className="subtitulo-login">Ingresa tus credenciales para continuar</p>
                
                {/* Mensaje de Error (solo se muestra si el backend falló) */}
                {error && (
                    <div style={{ color: 'red', textAlign: 'center', marginBottom: '1rem', padding: '0.5rem', backgroundColor: '#fee2e2', borderRadius: '4px' }}>
                        {error}
                    </div>
                )}

                {/* Formulario Principal */}
                <form id="formulario-acceso" className="formulario" onSubmit={manejarEnvio}>
                    
                    {/* Campo de Usuario */}
                    <div className="grupo-input">
                        <label htmlFor="entrada-usuario" className="etiqueta">Usuario</label>
                        <input 
                            id="entrada-usuario"
                            type="text" 
                            className="campo-texto" 
                            value={usuario}
                            onChange={(e) => setUsuario(e.target.value)}
                            disabled={cargando}
                            required
                        />
                    </div>
                    
                    {/* Campo de Contraseña */}
                    <div className="grupo-input">
                        <label htmlFor="entrada-contrasena" className="etiqueta">Contraseña</label>
                        <input 
                            id="entrada-contrasena"
                            type="password" 
                            className="campo-texto"
                            value={contrasena}
                            onChange={(e) => setContrasena(e.target.value)}
                            disabled={cargando}
                            required
                        />
                    </div>
                    
                    {/* Botón de Envío */}
                    <button id="boton-ingresar" type="submit" className="boton-primario" disabled={cargando}>
                        {cargando ? 'Ingresando...' : 'Ingresar'}
                    </button>
                </form>
            </div>
        </div>
    );
};
