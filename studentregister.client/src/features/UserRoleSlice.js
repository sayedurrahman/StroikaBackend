import { createSlice } from "@reduxjs/toolkit";

// Initial state
const initialState = {
    role: "Admin"
};

const userRoleSlice = createSlice({
    name: "userRole",
    initialState,
    reducers: {
        setAdmin: (state) => {
            state.role = 'Admin'
        },
        setRegistrar: (state) => {
            state.role = 'Registrar'
        }
    }
});

// Export actions
export const { setAdmin, setRegistrar } = userRoleSlice.actions

// Export reducer
export default userRoleSlice.reducer;