import { useAuth } from "../context/AuthContext";

export default function ProfilePage() {
  const { user, logout } = useAuth();
  return (
    <div>
      <h2>Profile</h2>
      <p>User: {user?.name}</p>
      <p>Token: {user?.token}</p>
      <button onClick={logout}>Logout</button>
    </div>
  );
}
