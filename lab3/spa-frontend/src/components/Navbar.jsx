import { Link } from "react-router-dom";
import { useAuth } from "../context/AuthContext";

export default function Navbar() {
  const { user } = useAuth();

  return (
    <nav style={{ display: "flex", gap: "1rem" }}>
      <Link to="/">Login</Link>
      {user && (
        <>
          <Link to="/dashboard">Dashboard</Link>
          <Link to="/profile">Profile</Link>
        </>
      )}
    </nav>
  );
}
