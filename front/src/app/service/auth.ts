import { Injectable } from '@angular/core';
import {
  getAuth,
  GoogleAuthProvider,
  signInWithPopup,
  signOut,
  User,
} from 'firebase/auth';

@Injectable({
  providedIn: 'root',
})
export class Auth {
  private auth = getAuth();

  async signInWithGoogle() {
    const provider = new GoogleAuthProvider();
    provider.setCustomParameters({ prompt: 'select_account' });
    try {
      const result = await signInWithPopup(this.auth, provider);
      const token = await result.user.getIdToken();
      localStorage.setItem('token', token);
      localStorage.setItem('user', JSON.stringify(result.user));
      return token;
    } catch (error) {
      throw error;
    }
  }

  async logOut(): Promise<void> {
    await signOut(this.auth);
    localStorage.removeItem('token');
  }

  getCurrentUser(): User | null {
    return localStorage.getItem('user')
      ? JSON.parse(localStorage.getItem('user') || '{}')
      : null;
  }

  async getToken() {
    const user = this.auth.currentUser;
    const token = user ? await user.getIdToken() : null;
    return token;
  }
}
