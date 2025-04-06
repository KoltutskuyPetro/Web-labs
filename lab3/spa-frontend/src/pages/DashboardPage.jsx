import { useAuth } from "../context/AuthContext";

export default function DashboardPage() {
  const { user } = useAuth();
  return (
    <div>
      <h2>Dashboard</h2>
      <p>Welcome, {user?.name}</p>
    </div>
  );
}
