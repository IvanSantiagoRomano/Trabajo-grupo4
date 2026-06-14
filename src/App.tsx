import LoginPage from './features/auth/components/LoginPage';
import './App.css'; // Si usás estilos globales, si no podés borrar esta línea

function App() {
    return (
        <div className="app-container">
            <LoginPage />
        </div>
    );
}

export default App;