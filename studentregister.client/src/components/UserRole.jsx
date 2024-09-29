import { useSelector, useDispatch } from 'react-redux';
import { setAdmin, setRegistrar } from '../features/UserRoleSlice';
import { Form } from 'react-bootstrap';


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
            <Form.Select aria-label="Default select example" value={role} onChange={handleChange}>
                <option value="Admin">Admin</option>
                <option value="Registrar">Registrar</option>
            </Form.Select>
            <h1>{role} Dashboard - Student List</h1>
        </div>
    );
}

export default UserRole;