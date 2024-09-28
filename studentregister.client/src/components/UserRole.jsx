import React from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { setAdmin, setRegistrar } from '../features/UserRoleSlice';

const UserRole = () => {
    const role = useSelector((state) => state.userRole.role);
    const dispatch = useDispatch();

    const handleChange = (event) => {
        const selectedRole = event.target.value;
        if (selectedRole === 'Admin') {
            dispatch(setAdmin());
        } else if (selectedRole === 'Registrar') {
            dispatch(setRegistrar());
        }
    };

    return (
        <div>
            <header>
                <select value={role} onChange={handleChange}>
                    <option value="Admin">Admin</option>
                    <option value="Registrar">Registrar</option>
                </select>
                <h1>{role} Dashboard</h1>
            </header>
        </div>
    );
}

export default UserRole;