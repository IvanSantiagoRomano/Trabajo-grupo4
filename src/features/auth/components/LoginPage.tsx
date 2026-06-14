import { useState } from "react";

function LoginPage() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState<string | null>(null);
    const [isLoading, setIsLoading] = useState(false);

    const handleLogin = async () => {
        setError(null);
        setIsLoading(true);

        try {
            // Reemplaza con la URL real de tu backend en .NET (ej: https://localhost:7001)
            const response = await fetch("https://localhost:7001/api/auth/login", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({ username, password }),
            });

            const data = await response.json();

            if (!response.ok) {
                throw new Error(data.message || "Error al iniciar sesión");
            }

            // --- ¡ÉXITO! ---
            console.log("Login exitoso, datos recibidos:", data);

        } catch (err: any) {
            // Capturamos el error para mostrárselo al usuario en la interfaz
            setError(err.message);
        } finally {
            setIsLoading(false);
        }
    };

    return (
        <div className="min-vh-100 d-flex align-items-center justify-content-center bg-light">
            <div className="card shadow w-100 mx-3" style={{ maxWidth: "400px" }}>
                <div className="card-body p-4">
                    <h2 className="text-center mb-1 fw-bold">GestiAutos</h2>
                    <p className="text-center text-muted mb-4">Ingresá a tu cuenta</p>

                    {/* Alerta visual por si el ExceptionHandler del backend arroja un error */}
                    {error && (
                        <div className="alert alert-danger py-2 text-center" role="alert">
                            {error}
                        </div>
                    )}

                    <div className="mb-3">
                        <label className="form-label">Usuario</label>
                        <input
                            type="text"
                            className="form-control"
                            placeholder="Tu nombre de usuario"
                            value={username}
                            disabled={isLoading}
                            onChange={e => setUsername(e.target.value)}
                        />
                    </div>

                    <div className="mb-4">
                        <label className="form-label">Contraseña</label>
                        <input
                            type="password"
                            className="form-control"
                            placeholder="Tu contraseña"
                            value={password}
                            disabled={isLoading}
                            onChange={e => setPassword(e.target.value)}
                        />
                    </div>

                    <button
                        className="btn btn-primary w-100"
                        onClick={handleLogin}
                        disabled={isLoading || !username || !password}
                    >
                        {isLoading ? "Ingresando..." : "Ingresar"}
                    </button>
                </div>
            </div>
        </div>
    );
}

export default LoginPage;