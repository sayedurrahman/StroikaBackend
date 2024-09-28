import { configureStore } from '@reduxjs/toolkit';
import userRoleReducer from '../features/UserRoleSlice';

export const store = configureStore({
    reducer: {
        userRole: userRoleReducer,
    },
});