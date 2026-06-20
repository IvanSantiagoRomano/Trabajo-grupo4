// Hecho por Tobias Guzzo
import React, { useState, useEffect } from 'react';
import './VehicleDashboard.css';

interface Vehiculo {
    id: number;
    nombre: string;
    descripcion: string;
    anio: number;
    kilometraje: string;
    precio: string;
    imagen: string;
}

export const VehicleDashboard = () => {
    const [vehiculos, setVehiculos] = useState<Vehiculo[]>([]);
    const [cargando, setCargando] = useState(true);

    useEffect(() => {
        // Conexión al backend en C#. 
        // Nota: Asegúrate de que tu backend esté corriendo en este puerto, o actualiza la URL.
        fetch('http://localhost:5000/api/vehicles')
            .then(response => {
                if (!response.ok) throw new Error('Error en la red');
                return response.json();
            })
            .then(data => {
                setVehiculos(data);
                setCargando(false);
            })
            .catch(error => {
                console.error('Error al obtener los vehículos del backend:', error);
                setCargando(false);
            });
    }, []);

    return (
        <div className="contenedor-principal">
            <header className="cabecera">
                <div className="contenido-cabecera">
                    <h1>GestiAutos</h1>
                    <nav className="navegacion">
                        <a href="#" className="activo">Inventario</a>
                        <a href="#">Financiación</a>
                        <a href="#">Servicio</a>
                    </nav>
                    <button className="boton-primario">Ingresar</button>
                </div>
            </header>

            <main className="contenido-central">
                <div className="seccion-hero">
                    <h2>Libera la Potencia.</h2>
                    <p>Descubre nuestra selección premium de autos clásicos y potentes.</p>
                </div>

                {cargando ? (
                    <div style={{ textAlign: 'center', color: 'var(--texto)' }}>
                        <p>Cargando inventario desde el servidor...</p>
                    </div>
                ) : vehiculos.length === 0 ? (
                    <div style={{ textAlign: 'center', color: 'var(--texto)' }}>
                        <p>No se encontraron vehículos. (Asegúrate de que el backend C# esté encendido y devolviendo datos).</p>
                    </div>
                ) : (
                    <div className="grilla-vehiculos">
                        {vehiculos.map(vehiculo => (
                            <div key={vehiculo.id} className="tarjeta-vehiculo">
                                <div className="contenedor-imagen">
                                    <img src={vehiculo.imagen} alt={vehiculo.nombre} className="imagen-tarjeta" />
                                    <div className="etiqueta-anio">{vehiculo.anio}</div>
                                </div>
                                <div className="cuerpo-tarjeta">
                                    <h3>{vehiculo.nombre}</h3>
                                    <p className="descripcion-vehiculo">{vehiculo.descripcion}</p>
                                    <div className="especificaciones">
                                        <span><i className="icono-ruta"></i> {vehiculo.kilometraje}</span>
                                    </div>
                                    <div className="pie-tarjeta">
                                        <span className="precio">{vehiculo.precio}</span>
                                        <button className="boton-secundario">Ver Detalles</button>
                                    </div>
                                </div>
                            </div>
                        ))}
                    </div>
                )}
            </main>
        </div>
    );
};
