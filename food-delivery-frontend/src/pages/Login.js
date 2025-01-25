import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import './Login.css';

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [success, setSuccess] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post('http://localhost:5160/api/auth/login', {
        email,
        password,
      });
      localStorage.setItem('token', response.data.token);
      setSuccess('Login successful!');
      setTimeout(() => navigate('/'), 2000);
    } catch (err) {
      setError('Invalid email or password');
    }
  };

  return (
    <div className="auth-container">
      <header className="auth-header">
        <h1>Delivery.Eats</h1>
        <nav>
          <a href="/menu">Menu</a>
          <a href="/orders">Orders</a>
          <a href="/cart">Cart</a>
        </nav>
        <div className="user-info">
          <span>example@mail.ru</span>
          <button onClick={() => navigate('/logout')}>Log out</button>
        </div>
      </header>

      <div className="login-box">
        <h2>Authorization</h2>
        {error && <p className="error-message">{error}</p>}
        {success && <p className="success-message">{success}</p>}
        <form onSubmit={handleSubmit}>
          <div className="input-group">
            <label htmlFor="email">Email</label>
            <input
              type="email"
              id="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              required
            />
          </div>
          <div className="input-group">
            <label htmlFor="password">Password</label>
            <input
              type="password"
              id="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              required
            />
          </div>
          <button type="submit" className="login-button">Log in</button>
        </form>
      </div>

      <footer className="auth-footer">
        <p>© 2023 Delivery.Eats</p>
      </footer>
    </div>
  );
};

export default Login;