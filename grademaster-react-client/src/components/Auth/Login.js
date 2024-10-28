import React, { useState } from 'react';
import { login } from '../../services/ApiCalls/auth';
import { useNavigate, Link } from 'react-router-dom';

import { Modal, Button, Form, Container } from 'react-bootstrap';

const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await login({ email, password });
            if (response.status === 200) {
                console.log("Frontend: Login successful!");

                //add authenticating for the current user
                const token = true;
                const loginTime = Date.now();
                localStorage.setItem("token", token);
                localStorage.setItem("loginTime", loginTime);
                sessionStorage.setItem("sessionToken", token);
                navigate('/');
            } else {
                console.error("Login failed.");
            }
        } catch (error) {
            console.error("Login failed:", error.response?.data || error.message);
        }
    };

    return (
        <Container>
            <Modal show centered backdrop={false} keyboard={false}>

                <Modal.Header className="d-flex justify-content-center">
                    <Modal.Title className="text-center">Login</Modal.Title>
                </Modal.Header>

                <Modal.Body>
                    <Form>
                        <Form.Group className="mb-3" controlId="formEmail">
                            <Form.Label>Email</Form.Label>
                            <Form.Control
                                type="email"
                                placeholder="Enter your email"
                                value={email}
                                onChange={(e) => setEmail(e.target.value)}
                                required
                            />
                        </Form.Group>
                        <Form.Group className="mb-3" controlId="formPassword">
                            <Form.Label>Password</Form.Label>
                            <Form.Control
                                type="password"
                                placeholder="Enter your password"
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                                required
                            />
                        </Form.Group>
                    </Form>
                </Modal.Body>

                <Modal.Footer className="d-flex flex-column justify-content-center">
                    <Button type="submit" onClick={handleSubmit} className="btn  btn-primary btn-block w-100">
                        <h5>Login</h5>
                    </Button>
                    <p className="mt-2">
                        Don't have an account? <Link to="/register">Register</Link>
                    </p>
                </Modal.Footer>
            </Modal>

        </Container>
    );
};

export default Login;
