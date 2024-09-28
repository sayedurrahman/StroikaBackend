import React from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { toggleRole } from '../features/UserRoleSlice';

const UserRole = () => {
    const role = useSelector((state) => state.userRole.role);
    const dispatch = useDispatch();

    return (
        <div>
            <header>
                <h2>Current Role: {role}</h2>
                <select value={role} onChange={(e) => dispatch(toggleRole())}>
                    <option value="Admin">Admin</option>
                    <option value="Registrar">Registrar</option>
                </select>
                <h1>{role} Dashboard</h1>
            </header>
            <main>
                <p>test</p>
            </main>
        </div>
    );
}

export default UserRole;