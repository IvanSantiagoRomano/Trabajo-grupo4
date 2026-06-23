// ==========================================
// SERVICIOS DE USUARIO (Conexión al Backend)
// ==========================================
// Este archivo centraliza todas las peticiones a la API para la entidad Usuario,
// mapeando directamente a los Casos de Uso (Use Cases) definidos en el backend en C#.

const API_URL = "https://localhost:7001/api/users"; // URL base para los endpoints de usuarios
const AUTH_URL = "https://localhost:7001/api/auth"; // URL específica para la autenticación

export interface Privilege {
    id?: number;
    name: string;
}

// Interfaz que refleja el UserDTO del backend
export interface UserDTO {
    id?: string;
    username: string;
    password?: string;
    name: string;
    lastName: string;
    taxId: string;
    docNumber: string;
    email: string;
    phoneNumber: string;
    address: string;
    privileges?: Privilege[];
}

// ---------------------------------------------------------
// FUNCIÓN AUXILIAR (Optimización)
// ---------------------------------------------------------
// Evita repetir la lógica de armar la petición y revisar si hubo error (response.ok)
// en cada una de las llamadas que hacemos abajo.
const fetchApi = async (url: string, options?: RequestInit) => {
    const response = await fetch(url, {
        ...options,
        headers: {
            "Content-Type": "application/json",
            ...options?.headers,
        },
    });

    if (!response.ok) {
        // Captura el mensaje que manda el ExceptionHandler del backend (si existe)
        const errorData = await response.json().catch(() => null);
        throw new Error(errorData?.message || `Error en la petición: ${response.statusText}`);
    }

    // Algunas respuestas (como DELETE) pueden venir sin contenido (204 No Content)
    return response.status !== 204 ? response.json() : true;
};

export const userService = {
    // ---------------------------------------------------------
    // AUTENTICACIÓN (Mapea a: Process/UCLoginUser)
    // ---------------------------------------------------------
    login: (username: string, password: string) => 
        fetchApi(`${AUTH_URL}/login`, {
            method: "POST",
            body: JSON.stringify({ username, password }),
        }),

    // ---------------------------------------------------------
    // COMANDOS (Mapea a: Commands/*)
    // ---------------------------------------------------------
    createUser: (user: UserDTO) => 
        fetchApi(API_URL, { method: "POST", body: JSON.stringify(user) }),

    updateUser: (id: string, user: UserDTO) => 
        fetchApi(`${API_URL}/${id}`, { method: "PUT", body: JSON.stringify(user) }),

    softDeleteUser: (id: string) => 
        fetchApi(`${API_URL}/${id}`, { method: "DELETE" }),

    // ---------------------------------------------------------
    // CONSULTAS (Mapea a: Queries/*)
    // ---------------------------------------------------------
    getAllUsers: () => fetchApi(API_URL),

    getAllDeletedUsers: () => fetchApi(`${API_URL}/deleted`),

    getUserById: (id: string) => fetchApi(`${API_URL}/${id}`)
};
