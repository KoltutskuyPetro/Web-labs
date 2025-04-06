import { Routes, Route } from "react-router-dom";
import LoginPage from "./pages/LoginPage";
import DashboardPage from "./pages/DashboardPage";
import ProfilePage from "./pages/ProfilePage";
import { useAuth } from "./context/AuthContext";
import Navbar from "./components/Navbar";

export default function App() {
  const { user } = useAuth();

  return (
    <div>
      <Navbar />
      <Routes>
        <Route path="/" element={<LoginPage />} />
        {user && <Route path="/dashboard" element={<DashboardPage />} />}
        {user && <Route path="/profile" element={<ProfilePage />} />}
      </Routes>
    </div>
  );
}
