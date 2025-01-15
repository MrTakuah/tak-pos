// Import the authentication middleware from Clerk
import { authMiddleware } from "@clerk/nextjs";
 
// Configure and export the middleware
export default authMiddleware({
  // Array of routes that don't require authentication
  publicRoutes: ["/"]
});
 
// Configure which routes the middleware applies to
export const config = {
  matcher: [
    // Match all paths except:
    '/((?!.+\\.[\\w]+$|_next).*)',  // Files with extensions (like images)
    '/',                             // Root path
    '/(api|trpc)(.*)'               // API and tRPC routes
  ],
};