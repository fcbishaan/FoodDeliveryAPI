import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import './Register.css';

const Register = () => {
  const [name, setName] = useState('');
  const [gender, setGender] = useState('Male');
  const [phone, setPhone] = useState('');
  const [dateOfBirth, setDateOfBirth] = useState('');
  const [address, setAddress] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  // Phone number mask validation
  const handlePhoneChange = (e) => {
    const value = e.target.value.replace(/\D/g, ''); // Remove non-digits
    let formattedValue = '+7 (';
    if (value.length > 1) {
      formattedValue += value.slice(1, 4) + ') ' + value.slice(4, 7) + '-' + value.slice(7, 9) + '-' + value.slice(9, 11);
    }
    setPhone(formattedValue);
  };

  // Form validation
  const validateForm = () => {
    if (!name || !email || !password || !phone || !dateOfBirth || !address) {
      setError('All fields are required.');
      return false;
    }

    if (!/^[a-zA-Z\s]+$/.test(name)) {
      setError('Name must contain only letters and spaces.');
      return false;
    }

    if (!/^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$/.test(email)) {
      setError('Invalid email address.');
      return false;
    }

    if (password.length < 6) {
      setError('Password must be at least 6 characters long.');
      return false;
    }

    if (!/^\+7 \(\d{3}\) \d{3}-\d{2}-\d{2}$/.test(phone)) {
      setError('Invalid phone number format. Use +7 (xxx) xxx-xx-xx.');
      return false;
    }

    return true;
  };

  // Handle form submission
  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');

    if (!validateForm()) {
      return;
    }

    try {
      const response = await axios.post('http://localhost:5160/api/auth/register', {
        FullName: name, 
        PhoneNumber: phone, 
        Gender: gender,
        DateOfBirth: dateOfBirth,
        Address: address,
        Email: email,
        Password: password,
      });
  

      
      localStorage.setItem('token', response.data.token);
      navigate('/'); 
    } catch (err) {
      setError('Registration failed. Please try again.');
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

      <div className="register-box">
        <h2>Register new account</h2>
        {error && <p className="error-message">{error}</p>}
        <form onSubmit={handleSubmit}>
          <div className="input-group">
            <label htmlFor="name">Name</label>
            <input
              type="text"
              id="name"
              value={name}
              onChange={(e) => setName(e.target.value)}
              required
            />
          </div>

          <div className="input-group">
            <label htmlFor="gender">Gender</label>
            <select
              id="gender"
              value={gender}
              onChange={(e) => setGender(e.target.value)}
              required
            >
              <option value="Male">Male</option>
              <option value="Female">Female</option>
            </select>
          </div>

          <div className="input-group">
            <label htmlFor="phone">Phone number</label>
            <input
              type="tel"
              id="phone"
              value={phone}
              onChange={handlePhoneChange}
              placeholder="+7 (xxx) xxx-xx-xx"
              required
            />
          </div>

          <div className="input-group">
            <label htmlFor="dateOfBirth">Date of birth</label>
            <input
              type="date"
              id="dateOfBirth"
              value={dateOfBirth}
              onChange={(e) => setDateOfBirth(e.target.value)}
              required
            />
          </div>

          <div className="input-group">
            <label htmlFor="address">Address</label>
            <input
              type="text"
              id="address"
              value={address}
              onChange={(e) => setAddress(e.target.value)}
              required
            />
          </div>

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

          <button type="submit" className="register-button">Register</button>
        </form>
      </div>

      <footer className="auth-footer">
        <p>© 2023 Delivery.Eats</p>
      </footer>
    </div>
  );
};

export default Register;